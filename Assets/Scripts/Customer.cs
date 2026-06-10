using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private float orderTimeLimit = 30f;

    private float remainingTime;
    private bool isActive;

    public float RemainingTime => remainingTime;

    private CustomerSpawner spawner;

    public PizzaType Order { get; private set; }


    public void Initialize(CustomerSpawner ownerSpawner)
    {
        spawner = ownerSpawner;

        remainingTime = orderTimeLimit;
        isActive = true;

        GenerateOrder();
    }

    private void GenerateOrder()
    {
        Order = (Random.value > 0.5f)
            ? PizzaType.Pepperoni
            : PizzaType.Plain;

        Debug.Log("Customer wants: " + Order);
    }

    public string GetOrderDialogue()
    {
        return Order == PizzaType.Plain
            ? "I want a plain pizza."
            : "I want a pepperoni pizza.";
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