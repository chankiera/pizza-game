using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject playAgainButton;

    private bool isEnded;

    private void Start()
    {
        ResetUI();
        isEnded = false;
    }

    public void ShowGameOver()
    {
        if (isEnded) return;

        isEnded = true;

        gameOverText.SetActive(true);
        winText.SetActive(false);
        playAgainButton.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        if (isEnded) return;

        isEnded = true;

        winText.SetActive(true);
        gameOverText.SetActive(false);
        playAgainButton.SetActive(true);

        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        Debug.Log("Play Again clicked");

        // Time.timeScale = 1f;

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetUI()
    {
        gameOverText.SetActive(false);
        winText.SetActive(false);
        playAgainButton.SetActive(false);
    }
}