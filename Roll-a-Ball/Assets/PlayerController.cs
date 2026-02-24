using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed = 10f;
    public float jumpForce = 15f;
    
    public AudioClip jumpSound;
    public AudioClip coinSound;

    public GameObject pickupVFX;    
    public GameObject explosionVFX;

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
        }
    }

    void OnTriggerEnter(Collider other)  
    {
        if (other.gameObject.CompareTag("coin"))
        {
            if (pickupVFX != null) 
            {
                Instantiate(pickupVFX, other.transform.position, Quaternion.identity);
            }

            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            other.gameObject.SetActive(false);
        }

        // For the Enemy/Explosion
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (explosionVFX != null)
            {
                Instantiate(explosionVFX, transform.position, Quaternion.identity);
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