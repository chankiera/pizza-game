using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Typewriter")]
    [SerializeField] private float characterDelay = 0.03f;

    private string[] dialogueLines;
    private int currentLine;
    private bool isTyping;
    private string currentFullLine;

    private bool isDialogueActive;

    public bool DialogueFinished { get; private set; }

    public Action OnDialogueComplete;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    public void StartDialogue(string[] lines, Action onComplete = null)
    {
        if (isDialogueActive)
            return;

        isDialogueActive = true;

        gameObject.SetActive(true);

        dialogueLines = lines;
        currentLine = 0;

        DialogueFinished = false;
        OnDialogueComplete = onComplete;

        StartCoroutine(TypeLine(dialogueLines[currentLine]));
    }

    public void StartCustomerOrder(Customer customer, Action onComplete = null)
    {
        string[] lines =
        {
            customer.GetOrderDialogue()
        };

        StartDialogue(lines, onComplete);
    }

    private void HandleClick()
    {
        if (!isDialogueActive)
            return;

        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentFullLine;
            isTyping = false;
            return;
        }

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
        isDialogueActive = false;
        DialogueFinished = true;

        gameObject.SetActive(false);

        OnDialogueComplete?.Invoke();

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