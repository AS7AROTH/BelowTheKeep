using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDistance = 5f;

    void Update()
    {
        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, spawnDistance))
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position =
                Camera.main.transform.position +
                Camera.main.transform.forward * spawnDistance;
        }

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