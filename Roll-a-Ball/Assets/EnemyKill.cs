using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit enemy!");

            // Replace this with your actual game over logic
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}