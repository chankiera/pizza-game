using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private float delayBetweenCustomers = 3f;

    public Customer CurrentCustomer;

    private bool serviceRunning;

    public void BeginService()
    {
        if (serviceRunning)
            return;

        serviceRunning = true;
        StartCoroutine(CustomerRoutine());
    }

    private IEnumerator CustomerRoutine()
    {
        while (serviceRunning)
        {
            SpawnCustomer();

            // Wait a short delay before showing order dialogue
            yield return new WaitForSeconds(0.5f);

            // Show customer order
            if (CurrentCustomer != null)
            {
                dialogueController.StartCustomerOrder(CurrentCustomer);
            }

            // Wait until the current customer is gone
            while (CurrentCustomer != null)
                yield return null;

            // Delay before next customer
            yield return new WaitForSeconds(delayBetweenCustomers);
        }
    }

    private void SpawnCustomer()
    {
        if (customerPrefabs == null || customerPrefabs.Length == 0)
        {
            Debug.LogError("No customer prefabs assigned!");
            return;
        }

        GameObject obj = Instantiate(
            customerPrefabs[Random.Range(0, customerPrefabs.Length)],
            spawnPoint.position,
            spawnPoint.rotation
        );

        CurrentCustomer = obj.GetComponent<Customer>();

        if (CurrentCustomer == null)
        {
            Debug.LogError("Customer prefab missing Customer script!");
            return;
        }

        CurrentCustomer.Initialize(this);
    }

    public void ClearCustomer()
    {
        CurrentCustomer = null;
    }

    public void StopService()
    {
        serviceRunning = false;
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        serviceRunning = false;
        CurrentCustomer = null;
    }
}