using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        //  distance between camera and player
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() 
    {
        // Moves the camera to follow the player, but keeps the original offset
        transform.position = player.transform.position + offset;
    }
}