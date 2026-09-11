using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Prefab que vamos a generar
    public float spawnDistance = 5f; // Distancia máxima

    void Update()
    {
        // Raycast desde la cámara
        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, spawnDistance))
        {
            // Colocamos el punto sobre la superficie detectada
            transform.position = hit.point;
        }
        else
        {
            // Si no detecta nada, usamos la distancia máxima
            transform.position =
                Camera.main.transform.position +
                Camera.main.transform.forward * spawnDistance;
        }

        // F para generar el cubo
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Instantiate(
                objectToSpawn,
                transform.position,
                Quaternion.identity
            );
        }
    }
}