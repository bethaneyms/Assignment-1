using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10f;
    public float jumpForce = 15f;

    private Rigidbody rb;
    private AudioSource audioSource;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        // Jump logic is best in Update to catch the button press instantly
        if (Input.GetKeyDown(KeyCode.Space)) { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("coin")) {
            other.gameObject.SetActive(false);
            
            // Optional: play sound if audioSource is attached
            if(audioSource != null) audioSource.Play();
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
} 
