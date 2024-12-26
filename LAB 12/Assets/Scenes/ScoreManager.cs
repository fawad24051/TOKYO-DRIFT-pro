//using UnityEngine;
//using UnityEngine.UI; // for UI text

//public class ScoreManager : MonoBehaviour
//{

//    public int score = 0; // current score
//    public Text scoreText; // UI text element to display score

//    // Method to add score
//    public void AddScore(int points)
//    {
//        score += points; // increment the score
//        UpdateScoreUI(); // update UI text
//    }

//    // Update the score text UI
//    private void UpdateScoreUI()
//    {
//        if (scoreText != null)
//        {
//            scoreText.text = "Score: " + score; // update the score UI text
//        }
//    }
//}


using UnityEngine;
using UnityEngine.UI;  // Required for working with UI elements

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Reference to the UI Text element to display the score
    private int score = 1;  // The score variable

    void Start()
    {
        // Ensure score starts at 0
        UpdateScoreText();
    }

    // Call this function when a coin is collected
    public void AddScore(int value)
    {
        score += value;  // Increase the score by the value passed
        UpdateScoreText();  // Update the UI text
    }

    // Update the UI Text with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();  // Update the UI text to show the score
        }
        else
        {
            Debug.LogError("ScoreText not assigned in the inspector!");
        }
    }
}

