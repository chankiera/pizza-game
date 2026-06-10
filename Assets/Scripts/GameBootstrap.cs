using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private DialogueController dialogue;

    [TextArea(3, 10)]
    [SerializeField] private string[] tutorialLines;

    private void Start()
    {
        dialogue.StartDialogue(tutorialLines);
    }
}