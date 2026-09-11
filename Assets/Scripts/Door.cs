using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false; // Estado de la puerta
    public PlayerMovement player; // Referencia al jugador

    public void Open()
    {
        // Comprobamos que exista el jugador
        if (player == null)
        {
            Debug.Log("NO HAY PLAYER ASIGNADO");
            return;
        }

        // Comprobamos si tiene la llave
        Debug.Log("Tiene llave: " + player.hasKey);

        if (!player.hasKey)
        {
            Debug.Log("NO TIENE LA LLAVE");
            return;
        }

        // Abrimos o cerramos la puerta
        if (isOpen)
        {
            transform.Rotate(0, -90, 0);
            isOpen = false;
        }
        else
        {
            transform.Rotate(0, 90, 0);
            isOpen = true;
        }
    }
}