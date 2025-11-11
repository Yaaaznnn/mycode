using UnityEngine;
using TMPro; 

public class CoinManager : MonoBehaviour
{
    
    public static CoinManager instance;

    // --- UI & Audio ---
    [SerializeField] private TMP_Text coinsDisplay;
    [SerializeField] private AudioClip coinSound;

    // --- Private Variables ---
    private int coins = 0;
    private AudioSource audioSource;

    // Awake runs before Start. This is where we set up the Singleton.
    
    private void Awake()
    {
        // If there is not already an 'instance' of this manager...
        if (instance == null)
        {
            // ...this one becomes the instance.
            instance = this;
        }
        else
        {
            // If an instance *already* exists, destroy this new one.
            Destroy(gameObject);
        }
    }

  
    private void Start()
    {
        // We get the AudioSource component that we must add to this GameObject.
        audioSource = GetComponent<AudioSource>();

        // Set the display to "0" when the game starts.
        coinsDisplay.text = coins.ToString();
    }

    
    // This is the public function that other scripts (like Coin.cs) will call.

    public void ChangeCoins(int amount)
    {
        // Add the amount to our total
        coins += amount;

        // Update the UI text
        coinsDisplay.text = coins.ToString();

        // Play the sound effect (if we assigned one in the Inspector)
        if (coinSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }
}
