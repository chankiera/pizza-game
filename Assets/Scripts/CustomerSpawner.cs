using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private float delayBetweenCustomers = 3f;

    public Customer CurrentCustomer { get; private set; }

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

            // wait a short delay before speaking
            yield return new WaitForSeconds(0.5f);

            dialogueController.StartCustomerOrder(CurrentCustomer);

            while (CurrentCustomer != null)
                yield return null;

            yield return new WaitForSeconds(delayBetweenCustomers);
        }
    }

    private void SpawnCustomer()
    {
        GameObject obj = Instantiate(
            customerPrefabs[Random.Range(0, customerPrefabs.Length)],
            spawnPoint.position,
            spawnPoint.rotation
        );

        CurrentCustomer = obj.GetComponent<Customer>();
        CurrentCustomer.Initialize(this);

        // IMPORTANT: show order AFTER spawn
        dialogueController.StartCustomerOrder(CurrentCustomer);
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