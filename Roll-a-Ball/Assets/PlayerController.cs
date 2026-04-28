using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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

    private Vector3 targetPos;
    [SerializeField] private bool isMoving = false;

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

            if (jumpSound != null) audioSource.PlayOneShot(jumpSound);

            if (jumpVFX != null) 
            {
                Instantiate(jumpVFX, transform.position, Quaternion.identity);
            }
        }

        // Mouse/touch click movement
        if (Pointer.current != null && Pointer.current.press.isPressed)
        {
            Vector2 aimPosition = Pointer.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(aimPosition);

            Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    targetPos = hit.point;
                    isMoving = true;
                }
            }
        }
        else
        {
            isMoving = false;
        }
    }

    void FixedUpdate() 
    {
        // Keyboard movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        // Mouse click movement
        if (isMoving)
        {
            Vector3 direction = targetPos - rb.position;
            direction.Normalize();

            rb.AddForce(direction * speed);
        }

        if (Vector3.Distance(rb.position, targetPos) < 0.5f)
        {
            isMoving = false;
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

            AudioSource.PlayClipAtPoint(coinSound, other.transform.position, 1.0f);

            other.gameObject.SetActive(false);
            Debug.Log("Coin collected!");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (explosionVFX != null)
            {
                Instantiate(explosionVFX, transform.position, Quaternion.identity);
            }

            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
            }

            gameObject.SetActive(false); 
        }
    }
}