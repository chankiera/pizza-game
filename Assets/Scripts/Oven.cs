using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform pizzaSpot;
    public GameObject ovenPrompt;
    public float ovenTime;

    private bool playerNearby;
    private bool pizzaInOven;

    void Start()
    {
        ovenPrompt.SetActive(false);
        pizzaInOven = false;
        ovenTime = 5f;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PutPizzaInOven();
        }
    }

    void PutPizzaInOven()
    {
        if (pizzaInOven)
        {
            return;
        }

        GameObject pizza = GameObject.FindWithTag("Pizza");

        pizza.transform.position = pizzaSpot.position;
        pizza.transform.rotation = pizzaSpot.rotation;

        pizzaInOven = true;
        Invoke(nameof(FinishCooking), ovenTime);
    }

    void FinishCooking()
    {
        Debug.Log("Finished cooking");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pizzaInOven)
        {
            playerNearby = true;
            ovenPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            ovenPrompt.SetActive(false);
        }
    }
}