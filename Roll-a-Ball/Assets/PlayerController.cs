using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        // the cennection between the script and the rigidbody component on the Player
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is best for Physics calculations
    void FixedUpdate()
    {
        // Detects the arrow keys and WASD for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Creates a direction vector (X, Y, Z) 
        // Leaves Y at 0 because the Player is not moiving in the air yet 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Pushes the ball in that direction
        rb.AddForce(movement * speed);
    }
}