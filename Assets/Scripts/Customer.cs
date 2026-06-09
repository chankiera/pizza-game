using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float orderTimeLimit = 30f;

    private float remainingTime;
    private bool isActive;

    public float RemainingTime => remainingTime;

    private CustomerSpawner spawner;

    public void Initialize(CustomerSpawner ownerSpawner)
    {
        spawner = ownerSpawner;

        remainingTime = orderTimeLimit;
        isActive = true;
    }

    void Update()
    {
        if (!isActive)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            LeaveAngry();
        }
    }

    public void ServeCustomer()
    {
        if (!isActive) return;

        isActive = false;
        spawner?.ClearCustomer();
        Destroy(gameObject);
    }

    private void LeaveAngry()
    {
        if (!isActive) return;

        isActive = false;
        spawner?.ClearCustomer();
        Destroy(gameObject);
    }
}