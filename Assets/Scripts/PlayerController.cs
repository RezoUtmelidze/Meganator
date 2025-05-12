using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30;
    public float rotationSpeed = 20;
    public Vector3 direction = new Vector3();
    public bool Jumpability = true;
    public Rigidbody rb;
    public Camera camera;
    public float JumpForce = 350;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        
        direction.x = Input.GetAxisRaw("Vertical");
        direction.z = -Input.GetAxisRaw("Horizontal");
        direction.Normalize();
        Vector3 refinedDirection = direction * ByTime(speed);
        transform.Translate(refinedDirection);
        if (Input.anyKey)
        {
            Debug.Log($"Standard vector: {direction} Refined vector: {refinedDirection}");
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, ByTime(rotationSpeed), 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -ByTime(rotationSpeed), 0);
        }
    }
    public void Jump()
    {
        if (Jumpability)
        {
            rb.AddForce(0, JumpForce, 0);
            Jumpability = false;
        }
    }

    public void Mover(float x, float y, float z)
    {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Jumpability = true;
    }
    public void OnCollisionExit(Collision coll)
    {
        if (Touched(coll, "Floor1"))
        {
            speed = 20;
        }else if (Touched(coll, "Floor2"))
        {
            speed = 15;
        }
    }

    public float ByTime(float force)
    {
        return force*Time.deltaTime;
    }
    public bool Touched(Collision collision, string tag)
    {
        return collision.collider.CompareTag("Floor1");
    }
}
