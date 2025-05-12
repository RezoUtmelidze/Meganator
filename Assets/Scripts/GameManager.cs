using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GameObjecter;
    public Transform spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(GameObjecter,spawnPosition.position,Quaternion.identity);
    }
}
