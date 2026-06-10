using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Timer gameTimer;
    [SerializeField] private CustomerSpawner customerSpawner;
    public EndScreen endscreen;

    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (started)
            return;

        if (!dialogueController.DialogueFinished)
            return;

        if (other.CompareTag("Player"))
        {
            started = true;

            gameTimer.StartTimer();
            customerSpawner.BeginService();

            Debug.Log("Shift Started!");
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy at our door!");
            endscreen.ShowGameOver();
        }
    }
}