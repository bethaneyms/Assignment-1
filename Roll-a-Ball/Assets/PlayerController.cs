using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour 
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float jumpForce = 15f;
    
    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip coinSound;

    [Header("VFX Prefabs")]
    public GameObject pickupVFX;    
    public GameObject explosionVFX;
    public GameObject jumpVFX;

    [Header("UI Reference")]
    public TextMeshProUGUI gameOverText; 

    private Rigidbody rb;
    private AudioSource audioSource; 

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            if(jumpSound != null) audioSource.PlayOneShot(jumpSound);

            if (jumpVFX != null) 
            {
                Instantiate(jumpVFX, transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter(Collider other)  
    {
        // Handling Coin Pickups
        if (other.gameObject.CompareTag("coin"))
        {
            if (pickupVFX != null) 
            {
                Instantiate(pickupVFX, other.transform.position, Quaternion.identity);
            }

            // Spatial audio played at 100% volume
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position, 1.0f);
            
            other.gameObject.SetActive(false);
            Debug.Log("Coin collected!");
        }

        // Handling Enemy Collisions
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (explosionVFX != null)
            {
                Instantiate(explosionVFX, transform.position, Quaternion.identity);
            }

            // Trigger Game Over UI if it exists
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
            }

            gameObject.SetActive(false); 
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