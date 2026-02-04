using UnityEngine;

public class Rotator : MonoBehaviour
{
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        // Rotates the cube smoothly over time
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}