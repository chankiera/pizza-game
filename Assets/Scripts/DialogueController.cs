using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Dialogue")]
    [TextArea(3, 10)]
    [SerializeField] private string[] dialogueLines;

    [Header("Typewriter")]
    [SerializeField] private float characterDelay = 0.03f;

    public bool DialogueFinished { get; private set; }

    private int currentLine = 0;
    private bool isTyping = false;
    private string currentFullLine;

    private void Start()
    {
        DialogueFinished = false;

        if (dialogueLines.Length > 0)
        {
            StartCoroutine(TypeLine(dialogueLines[currentLine]));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        // Finish current line instantly
        if (isTyping)
        {
            StopAllCoroutines();

            dialogueText.text = currentFullLine;
            isTyping = false;
            return;
        }

        // Move to next line
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            StartCoroutine(TypeLine(dialogueLines[currentLine]));
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        DialogueFinished = true;

        // Hide dialogue UI
        gameObject.SetActive(false);

        Debug.Log("Dialogue Finished");
    }

    private IEnumerator TypeLine(string line)
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