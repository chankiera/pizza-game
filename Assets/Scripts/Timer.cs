using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private float startingTime = 300f; // 5 minutes

    private float remainingTime;
    private bool timerRunning = false;

    void Start()
    {
        remainingTime = startingTime;

        // Hide timer until dialogue is finished
        timerText.gameObject.SetActive(false);

        UpdateDisplay();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime < 0)
                remainingTime = 0;

            UpdateDisplay();
        }
    }

    public void StartTimer()
    {
        timerText.gameObject.SetActive(true);
        timerRunning = true;
    }

    private void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}