using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float sensitivity = 0.2f;

    private float rotationX = 20f;
    private float rotationY = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        if (Mouse.current != null)
        {
            Vector2 mouse = Mouse.current.delta.ReadValue();

            rotationY += mouse.x * sensitivity;
            rotationX -= mouse.y * sensitivity;
        }

        rotationX = Mathf.Clamp(rotationX, -20f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        Vector3 targetPosition = target.position + Vector3.up * height;

        Vector3 direction = -(rotation * Vector3.forward);

        float finalDistance = distance;

        RaycastHit hit;

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

        transform.LookAt(target.position + Vector3.up * 1f);
    }
}