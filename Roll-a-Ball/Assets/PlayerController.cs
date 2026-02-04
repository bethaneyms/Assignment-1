using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 15f;
    private Rigidbody rb;

    void Start()
    {
        // This connects the script to the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Makes the Player jump
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Detects when the Player overlaps with the coin
    void OnTriggerEnter(Collider other) 
    {
        // IMPORTANT: Make sure your coin tag is exactly "coin" in Unity!
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
}