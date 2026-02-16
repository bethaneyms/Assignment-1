using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed = 10f;
    public float jumpForce = 15f;
    
    // 1. Add these so you can drag your sounds in
    public AudioClip jumpSound;
    public AudioClip coinSound;

    private Rigidbody rb;
    private AudioSource audioSource; // 2. This fixes the 'audioSource' error!

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Connects the component
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Play jump sound
            if(jumpSound != null) audioSource.PlayOneShot(jumpSound);
        }
    }

    void OnTriggerEnter(Collider other)  
    {
        if (other.gameObject.CompareTag("coin"))
        {
            // Play coin sound at the coin's position
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
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