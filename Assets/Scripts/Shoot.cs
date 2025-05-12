using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ProjectileShootPoint;
    public GameObject Projectile;
    public float ShootForce = 500f;
    public float ShootQuantity = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            for(int i = 0; i < ShootQuantity; i++)
            {
                Instantiate(Projectile);
                GameObject projectileClone = Instantiate(Projectile, ProjectileShootPoint.position, Quaternion.identity);
                projectileClone.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce);
            }
        }
    }
}
