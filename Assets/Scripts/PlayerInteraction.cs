using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 10f; // Distancia máxima de interacción

    void Update()
    {
        // E para interactuar
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        // Raycast desde el centro de la cámara
        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0)
        );

        // Mostramos el Raycast en la escena
        Debug.DrawRay(
            ray.origin,
            ray.direction * interactionDistance,
            Color.red,
            2f
        );

        // Detectamos los objetos que están adelante
        RaycastHit[] hits = Physics.RaycastAll(
            ray,
            interactionDistance
        );

        foreach (RaycastHit hit in hits)
        {
            // Buscamos una puerta
            Door door = hit.collider.GetComponentInParent<Door>();

            if (door != null)
            {
                door.Open();
                return;
            }
        }
    }
}