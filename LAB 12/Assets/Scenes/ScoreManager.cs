using UnityEngine;
using UnityEngine.UI; // Ensure you have this namespace

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sManager; // Static reference to this script
    public int playerScore = 0; // Player's score

    public Text scoreText; // UI Text element to display the score (must be public)

    void Start()
    {
        if (sManager == null)
        {
            sManager = this; // Assign this instance to the static variable
        }
        else if (sManager != this)
        {
            Destroy(gameObject); // Destroy duplicate instances if any
        }

        DontDestroyOnLoad(gameObject); // Prevent destruction on scene change

        // Initialize score display
        if (scoreText != null)
        {
            UpdateScoreDisplay();
        }
        else
        {
            Debug.LogWarning("Score text UI element is not assigned.");
        }
    }

    // Method to increase the score
    public void IncreaseScore(int increase)
    {
        playerScore += increase;
        UpdateScoreDisplay(); // Update the score on the screen
    }

    // Method to update the score display
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }
}
