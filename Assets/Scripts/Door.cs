using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public PlayerMovement player;

    public void Open()
    {
        if (player == null)
        {
            Debug.Log("NO HAY PLAYER ASIGNADO");
            return;
        }

        Debug.Log("Tiene llave: " + player.hasKey);

        if (!player.hasKey)
        {
            Debug.Log("NO TIENE LA LLAVE");
            return;
        }

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