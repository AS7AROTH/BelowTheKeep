using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del jugador
    public float gravity = -9.81f; // Gravedad
    public float jumpForce = 6f; // Fuerza del salto
    public bool hasKey = false; // Indica si tiene la llave

    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        // Obtenemos el CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        // Movimiento con WASD
        if (Keyboard.current.wKey.isPressed)
            input.y = 1;

        if (Keyboard.current.sKey.isPressed)
            input.y = -1;

        if (Keyboard.current.aKey.isPressed)
            input.x = -1;

        if (Keyboard.current.dKey.isPressed)
            input.x = 1;

        // Dirección de movimiento según la cámara
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calculamos el movimiento
        Vector3 movement = forward * input.y + right * input.x;

        // Evita moverse más rápido en diagonal
        if (movement.magnitude > 1)
            movement.Normalize();

        movement *= speed;

        // Hace que el jugador mire hacia donde se mueve
        if (movement.magnitude > 0.1f)
        {
            transform.forward = movement.normalized;
        }

        // Comprobamos si está en el suelo
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;

            // Salto con la tecla Space
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            // Aplicamos la gravedad
            verticalVelocity += gravity * Time.deltaTime;
        }

        movement.y = verticalVelocity;

        // Movemos al jugador
        controller.Move(movement * Time.deltaTime);
    }
}