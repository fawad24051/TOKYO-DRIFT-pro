using UnityEngine;

public class SimpleCollectibleScript : MonoBehaviour
{
    public AudioClip collectSound;  // Sound when the coin is collected
    public GameObject collectEffect;  // Particle effect when collected

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player" (the car)
        if (other.CompareTag("Player"))
        {
            // Play the collection sound and effect if assigned
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // Update the score
            ScoreManager scoreScript = FindObjectOfType<ScoreManager>();
            if (scoreScript != null)
            {
                scoreScript.AddScore(1);  // Adds 1 point for each coin
            }

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
