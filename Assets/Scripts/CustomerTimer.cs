using TMPro;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private CustomerSpawner spawner;

    void Update()
    {
        Customer customer = spawner.CurrentCustomer;

        if (customer == null)
        {
            timerText.text = "";
            return;
        }

        timerText.text =
            $"Customer: {Mathf.CeilToInt(customer.RemainingTime)}s";
    }
}