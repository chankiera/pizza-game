using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPrefabs;
    [SerializeField] private Transform spawnPoint;
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

            while (CurrentCustomer != null)
                yield return null;

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

        GameObject prefab = customerPrefabs[Random.Range(0, customerPrefabs.Length)];

        GameObject obj = Instantiate(
            prefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        CurrentCustomer = obj.GetComponent<Customer>();

        if (CurrentCustomer == null)
        {
            Debug.LogError("Customer prefab missing Customer script!");
            return;
        }

        // IMPORTANT: inject reference instead of searching
        CurrentCustomer.Initialize(this);
    }

    public void ClearCustomer()
    {
        CurrentCustomer = null;
    }

    public void StopService()
    {
        serviceRunning = false;
    }
}