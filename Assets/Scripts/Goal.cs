using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si entró el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡OBJETIVO COMPLETADO!");
        }
    }
}