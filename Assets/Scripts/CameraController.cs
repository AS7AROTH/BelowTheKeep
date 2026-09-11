using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target; // Jugador que sigue la cámara
    public float distance = 5f; // Distancia de la cámara
    public float height = 2f; // Altura de la cámara
    public float sensitivity = 0.2f; // Sensibilidad del mouse

    private float rotationX = 20f;
    private float rotationY = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Movimiento de la cámara con el mouse
        if (Mouse.current != null)
        {
            Vector2 mouse = Mouse.current.delta.ReadValue();

            rotationY += mouse.x * sensitivity;
            rotationX -= mouse.y * sensitivity;
        }

        // Limitamos la cámara verticalmente
        rotationX = Mathf.Clamp(rotationX, -20f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        Vector3 targetPosition = target.position + Vector3.up * height;
        Vector3 direction = -(rotation * Vector3.forward);

        float finalDistance = distance;

        RaycastHit hit;

        // Detectamos paredes entre la cámara y el jugador
        if (Physics.Raycast(
            targetPosition,
            direction,
            out hit,
            distance
        ))
        {
            finalDistance = hit.distance - 0.2f;
        }

        transform.position = targetPosition + direction * finalDistance;

        // La cámara mira al jugador
        transform.LookAt(target.position + Vector3.up * 1f);
    }
}