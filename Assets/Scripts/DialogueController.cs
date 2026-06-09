using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueText;

    [Header("Dialogue")]
    [TextArea(3, 10)]
    public string[] dialogueLines;

    [Header("Typewriter")]
    public float characterDelay = 0.03f;

    private int currentLine = 0;
    private bool isTyping = false;
    private string currentFullLine;
    public Timer gameTimer;
    public CustomerSpawner spawner;

    void Start()
    {
        StartCoroutine(TypeLine(dialogueLines[currentLine]));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        if (isTyping)
        {
            StopAllCoroutines();

            dialogueText.text = currentFullLine;
            isTyping = false;
        }
        else
        {
            currentLine++;

            if (currentLine < dialogueLines.Length)
            {
                StartCoroutine(TypeLine(dialogueLines[currentLine]));
            }
            else
            {
                gameTimer.StartTimer();
                spawner.BeginService();
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        currentFullLine = line;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(characterDelay);
        }

        isTyping = false;
    }
}