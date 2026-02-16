using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // This rotates the object smoothly over time
        // Vector3(15, 30, 45) gives it that nice diagonal spin
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}