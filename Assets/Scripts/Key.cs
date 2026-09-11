using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();

        if (player != null)
        {
            player.hasKey = true;
            Debug.Log("LLAVE OBTENIDA");
            Destroy(gameObject);
        }
    }
}