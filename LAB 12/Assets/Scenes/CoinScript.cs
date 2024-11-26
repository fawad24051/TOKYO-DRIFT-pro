using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin Collected!"); // Log to verify if the collision happens
            ScoreManager.sManager.IncreaseScore(1); // Increase the score by 1
            Destroy(gameObject); // Destroy the coin after it is collected
        }
    }
}
