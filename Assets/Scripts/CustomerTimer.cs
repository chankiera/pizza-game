using TMPro;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private CustomerSpawner spawner;

    private void Start()
    {
        timerText.gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("CustomerTimer Update Running");

        Customer customer = spawner.CurrentCustomer;

        if (customer == null)
        {
            timerText.gameObject.SetActive(false);
            return;
        }

        timerText.gameObject.SetActive(true);

        timerText.text =
            $"Customer: {Mathf.CeilToInt(customer.RemainingTime)}s";
    }
}