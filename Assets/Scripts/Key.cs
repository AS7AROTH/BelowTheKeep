using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Buscamos al jugador
        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();

        if (player != null)
        {
            // Le damos la llave
            player.hasKey = true;

            Debug.Log("LLAVE OBTENIDA");

            // Eliminamos la llave
            Destroy(gameObject);
        }
    }
}