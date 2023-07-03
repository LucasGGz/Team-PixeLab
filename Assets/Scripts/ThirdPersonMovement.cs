using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    private float horizontal;
    private float vertical;
    public float speed = 6f;
    //variables prueba
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForwad;
    private Vector3 camRight;

    private Vector3 movePlayer;

    //Jump
   // Vector3 velocity;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public float distMax;

    //Dash & Movement
    public Vector3 moveDir;

    //Variables Animación
    public Animator animacion;
    public float factor;
    public Vector3 originOffset;

    private bool muerto;
    private bool atacando;
    private bool floorDetected = false;
    public bool conArma;
    private int cantidadClick;
    private bool puedoDarClick;
    public float clickCooldown;
    private float clickCooldownTimer;
    public bool avanza;
    public float impulsoGolpe = 10f;
    public GameObject efectoAura;
    public GameObject efectoCura;

    public int hpPlayer;
    public int danioEnemigo;
    //public BarraVidaBehaviour barraVida;
    public int danio;

    public bool aliadoSeguir;

    private bool isJump=false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animacion = GetComponent<Animator>();       //le asigna el componente Animator del player
        //Cursor.lockState = CursorLockMode.Locked;
        cantidadClick = 0;
        puedoDarClick = true;
        muerto = false;
        aliadoSeguir = true;
        //barraVida.vidaMax = hpPlayer;               //asigna el hp del player a una variable del script BarraVidaBehaviour
        //barraVida.vidaActual = hpPlayer;            //asigna el hp del player a una variable del script BarraVidaBehaviour

    }

    void FixedUpdate() //Las ejecuciones por segundo del fixedUpdate es fija, mientras que en el Update es variable
    {
        //en el update esto daba problemas
        if (avanza)
        {
            controller.Move(moveDir * impulsoGolpe * Time.deltaTime);
            //physicBody.velocity = transform.forward * impulsoGolpe; //hace que el player avanze por un momento cuando ataca
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            if (!atacando)
            {
                MovePlayer();//el player solo se puede mover si no esta muerto y si no se esta atacando
                
            }
            Debug.Log("Saltando: "+isJump);
            Atacar();
        }
        /*if (conArma && floorDetected)
        {
            clickCooldownTimer += Time.deltaTime;
            if (clickCooldownTimer >= clickCooldown)
            {
                puedoDarClick = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                iniciarCombo();
            }
        }*/
        
    }

    public void MovePlayer()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        animacion.SetFloat("PlayerWalkVelocity", playerInput.magnitude * speed);

        camDirection();

        moveDir = playerInput.x * camRight + playerInput.z * camForwad;
        movePlayer = moveDir * speed;

        controller.transform.LookAt(controller.transform.position + moveDir);


        setGravity();

        playerSkills();

        RaycastHit hit;
        Vector3 floor = transform.TransformDirection(Vector3.down);
        if (Physics.SphereCast(transform.position + originOffset, controller.radius / factor, floor, out hit, distMax))
        {
            animacion.SetBool("onFloor", true);
            floorDetected = true;
            isJump = false;
        }
        else
        {
            animacion.SetBool("onFloor", false);
            floorDetected = false;
            isJump = true;
        }

        //controller.Move(movePlayer.normalized * Time.deltaTime);
        //controller.Move (moveDir * speed * Time.deltaTime);
        controller.Move(movePlayer * Time.deltaTime);


        /*Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Jump
        /*isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && dir.magnitude <= 0.05f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }*/

        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
        //Debug.Log(controller.velocity.magnitude);
    }

    public void camDirection()
    {
        camForwad = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForwad.y = 0;
        camRight.y = 0;

        camForwad = camForwad.normalized;
        camRight = camRight.normalized;
    }

    public void playerSkills()
    {
        //isJump = Input.GetButtonDown("Jump");
        if (/*controller.isGrounded*/floorDetected && Input.GetButtonDown("Jump"))
        {
            isJump = true;
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            animacion.SetTrigger("Jump");
        }
    }
    public void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isJump)
        {
            animacion.SetTrigger("powerUp");
            atacando = true;
            Instantiate(efectoAura, controller.transform.position, controller.transform.rotation);
        }else if (Input.GetKeyDown(KeyCode.Q) && !isJump)
        {
            animacion.SetTrigger("curar");
            atacando = true;
            Instantiate(efectoCura, controller.transform.position, controller.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isJump)
        {
            Debug.Log(isJump);
            animacion.SetTrigger("darOrden");
            atacando = true;
            if (aliadoSeguir)
            {
                aliadoSeguir = false;
            }
            else
            {
                aliadoSeguir = true;
            }
        }
        if (conArma && floorDetected)
        {
            clickCooldownTimer += Time.deltaTime;
            if (clickCooldownTimer >= clickCooldown)
            {
                puedoDarClick = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                iniciarCombo();
            }
            if (Input.GetMouseButtonDown(1) && !atacando)
            {
                animacion.SetTrigger("ataque");
                atacando = true;
            }
            //else if (Input.GetMouseButtonDown(0))
            //{
            //    iniciarCombo();
            //}
        }
    }

    public void iniciarCombo()
    {

        if (puedoDarClick && cantidadClick < 3)
        {
            
            cantidadClick++;

        }

        if (cantidadClick == 1)
        {
            animacion.SetInteger("combo1", 1);
            atacando = true;
        }
    }

    public void setGravity()
    {
        if (controller.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    private void OnDrawGizmos()
    {
        controller = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position + originOffset, controller.radius / factor);
    }

    public void Animaciones()
    {
        /*if (controller.isGrounded)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position + originOffset, controller.radius / factor, -transform.up, out hit))
            {
                floorDetected = true;
                Debug.Log("PISO DETECTADO");
            }

        }
        else if (!controller.isGrounded)
        {
            floorDetected = false;
            Debug.Log("NO HAY SUELO");
        }*/
    }

    public void DejarDeGolpear()
    {
        atacando = false;
    }

    public void VerificadorCombo()
    {
        clickCooldownTimer = 0;
        puedoDarClick = false;

        if (animacion.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && cantidadClick==1)
        {
            animacion.SetInteger("combo1", 0);
            atacando = false;
            cantidadClick = 0;
            clickCooldownTimer = 0.5f;
        }
        else if (animacion.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && cantidadClick == 2)
        {
            animacion.SetInteger("combo1", 2);
            puedoDarClick = true;
        }
        else if (animacion.GetCurrentAnimatorStateInfo(0).IsName("GiroAttack") && cantidadClick == 2)
        {
            animacion.SetInteger("combo1", 0);
            atacando = false;
            puedoDarClick = true;
            cantidadClick = 0;
            //clickCooldownTimer = 0f;
        }
        else if (animacion.GetCurrentAnimatorStateInfo(0).IsName("GiroAttack") && cantidadClick == 3)
        {
            animacion.SetInteger("combo1", 3);
            //puedoDarClick = true;
        }
        else if (animacion.GetCurrentAnimatorStateInfo(0).IsName("LowJumpAttack"))
        {
            animacion.SetInteger("combo1", 0);
            atacando = false;
            cantidadClick = 0;
        }
        else
        {
            animacion.SetInteger("combo1", 0);
            atacando = false;
            cantidadClick = 0;
        }
        
    }
    public void AvanzoSolo()
    {
        avanza = true;
    }
    //cambia el estado de la variable avanza a falso
    public void DejaDeAvanzar()
    {
        avanza = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (!muerto)
        {
            if (other.gameObject.tag == "leftImpacto")
            {
                hpPlayer -= danioEnemigo;//disminuye el hp del player
                barraVida.vidaActual = hpPlayer;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            }
            if (hpPlayer <= 0)
            {
                animacion.SetTrigger("estoyMuerto");//esta animación se llama al cambiar la variable de tipo Trigger "estoyMuerto" que esta en el animator del Player
                muerto = true;          //cambia el estado de muerto a true
            }
        }
        /*if (other.gameObject.tag == "Finish")
        {
            hpPlayer -= danio;//disminuye el hp del player
            barraVida.vidaActual = hpPlayer;//se asigna el hp Actual a una variable del script BarraVidaBehaviour
            if (!muerto)
            {
                transform.position = new Vector3(62f, 62f, 42f);//mueve al player a una posicion
            }

        }*/

    }

    private void OnAnimatorMove()
    {
        
    }
}