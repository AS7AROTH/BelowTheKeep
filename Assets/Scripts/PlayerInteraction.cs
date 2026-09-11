using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 10f;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0)
        );

        Debug.DrawRay(
            ray.origin,
            ray.direction * interactionDistance,
            Color.red,
            2f
        );

        RaycastHit[] hits = Physics.RaycastAll(
            ray,
            interactionDistance
        );

        Debug.Log("Objetos detectados: " + hits.Length);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log(
                "Detectado: " + hit.collider.name +
                " | Distancia: " + hit.distance
            );

            Door door = hit.collider.GetComponentInParent<Door>();

            if (door != null)
            {
                Debug.Log("PUERTA ENCONTRADA");
                door.Open();
                return;
            }
        }

        Debug.Log("No encontré una puerta");
    }
}