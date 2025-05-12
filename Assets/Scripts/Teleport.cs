using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform spawnPosition;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = spawnPosition.position;
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
