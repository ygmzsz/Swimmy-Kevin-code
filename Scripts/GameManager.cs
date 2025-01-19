using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;  // The button itself
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        Debug.Log("Awake called");
        playButton.SetActive(true);  // Activate the button on start
        gameOver.SetActive(false);
        Pause();
    }

    public void Play()
    {
        Debug.Log("Play button pressed"); // Add Debug to confirm click event
        score = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);  // Hide the play button after starting the game

        Time.timeScale = 1f;
        player.enabled = true;

        // Destroy existing seaweeds
        Seaweed[] seaweed = FindObjectsOfType<Seaweed>();
        for (int i = 0; i < seaweed.Length; i++)
        {
            Destroy(seaweed[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOver.SetActive(true);
        playButton.SetActive(true);  // Ensure the play button is fully active

        // Ensure the Button component itself is interactable
        Button buttonComponent = playButton.GetComponent<Button>();
        if (buttonComponent != null)
        {
            Debug.Log("Reactivating the Button component");
            buttonComponent.interactable = true;  // Ensure button is interactable
        }

        Pause();
    }

    public void Scoring()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}
