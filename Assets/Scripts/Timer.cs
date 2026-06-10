using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startingTime = 300f;

    [SerializeField] private EndScreen endScreen;

    private float remainingTime;
    private bool timerRunning;

    private bool hasEnded;

    void Start()
    {
        remainingTime = startingTime;
        timerText.gameObject.SetActive(false);
        UpdateDisplay();
    }

    void Update()
    {
        if (!timerRunning || hasEnded)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            Win();
        }

        UpdateDisplay();
    }

    public void StartTimer()
    {
        timerText.gameObject.SetActive(true);
        timerRunning = true;
    }

    private void Win()
    {
        hasEnded = true;
        timerRunning = false;

        endScreen.ShowWin();
    }

    private void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}