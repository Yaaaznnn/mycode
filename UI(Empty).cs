using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIManager : MonoBehaviour
{
    // Singleton Instance so other scripts can call UIManager.instance.ShowGameOver();
    public static UIManager instance;

    [Header("UI Panels")]
    public GameObject gameOverPanel; // Drag your Game Over Panel here
    public GameObject victoryPanel;  // Drag your Win/Victory Panel here

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this function when the player dies
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pauses the game
        }
    }

    // Call this function when the player triggers the win condition
    public void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f; // Pauses the game
        }
    }

    // "Restart" Button
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        // Reloads the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // "Main Menu" Button
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");  
}

