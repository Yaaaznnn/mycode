using UnityEngine;

// This script goes on every coin. It waits for the player to touch it,
// then tells the CoinManager to add to the score and destroys itself.

public class Coin : MonoBehaviour
{
    // change this value in the Inspector for different coins
    [SerializeField] private int value = 1;

    // This is a safety check to prevent one coin from being triggered multiple times
    private bool hasTriggered = false;

    // A private variable to hold a reference to the manager
    private CoinManager coinManager;

    private void Start()
    {
        // On start, this coin finds the 'instance' of the CoinManager
        // and stores it in the 'coinManager' variable.
        coinManager = CoinManager.instance;
    }

    // This function runs automatically when another 2D collider
    // with "Is Trigger" checked enters this object's trigger.
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object that hit us has the tag "Player" AND we haven't been triggered yet...
        if (collision.CompareTag("nice person") && !hasTriggered)
        {
            // ...set hasTriggered to true so this can't run again.
            hasTriggered = true;

            // Tell the CoinManager to change the coin count by our 'value'.
            coinManager.ChangeCoins(value);

            // Destroy the coin GameObject.
            Destroy(gameObject);
        }
    }
}
