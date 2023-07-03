using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private Vector3 dashDirection;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private CharacterController characterController;
    private ThirdPersonMovement moveScript;
    public GameObject efectoPolvo;
    private SoundManager soundManager;
    // Start is called before the first frame update
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveScript = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            // Mover el objeto en la dirección del dash a la velocidad adecuada
            characterController.Move(dashDirection * dashDistance / dashDuration * Time.deltaTime);

            dashTimer += Time.deltaTime;
            if (dashTimer >= dashDuration)
            {
                // Terminar el dash después de la duración establecida
                isDashing = false;
                moveScript.animacion.SetBool("dashing", false);
                dashTimer = 0f;
            }
        }
        else
        {
            // Si no está realizando un dash, esperar al cooldown antes de permitir otro dash
            dashCooldownTimer += Time.deltaTime;
            if (dashCooldownTimer >= dashCooldown)
            {
                // Detectar la entrada del jugador para iniciar un dash en una dirección específica
                //float horizontalInput = Input.GetAxis("Horizontal");
                //float verticalInput = Input.GetAxis("Vertical");

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //dashDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
                    dashDirection = moveScript.moveDir;
                    StartDash();
                    soundManager.SeleccionAudio(2, 1f);
                }
            }
        }
    }
    private void StartDash()
    {
        // Iniciar el dash
       
        isDashing = true;
        dashCooldownTimer = 0f;
        moveScript.animacion.SetBool("dashing", true);
        Instantiate(efectoPolvo, moveScript.controller.transform.position, moveScript.controller.transform.rotation);
    }
}
