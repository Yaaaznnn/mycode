using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // "Play" Button
    public void PlayGame()
    {
        // Loads the scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Link this to your "Quit" Button
    public void QuitGame()
    {
        Debug.Log("Quitting Game..."); // Shows in Unity Console
        Application.Quit(); // Closes the game window (only works in the built game)
    }
}

