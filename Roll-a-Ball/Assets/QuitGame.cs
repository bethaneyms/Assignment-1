using UnityEngine;

public class MenuControls : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Button Pressed!"); 
        Application.Quit();
    }
}