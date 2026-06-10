using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform pizzaSpot;
    public GameObject ovenPrompt;
    public GameObject takeOutPrompt;
    public GameObject pizzaBox;
    public float ovenTime;
    public TextMeshProUGUI timerText;

    private bool playerNearby;
    private bool pizzaInOven;
    private float remainingTime;
    private bool cooking;
    private bool doneCooking;

    void Start()
    {
        ovenPrompt.SetActive(false);
        pizzaInOven = false;
        ovenTime = 5f;
        cooking = false;
        doneCooking = false;
        timerText.gameObject.SetActive(false);
        takeOutPrompt.SetActive(false);
        remainingTime = ovenTime;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !cooking)
        {
            PutPizzaInOven();
        }

        if (cooking)
        {
            remainingTime -= Time.deltaTime;

            timerText.text = "Cooking: " + Mathf.Ceil(remainingTime).ToString();

            if (remainingTime <= 0)
            {
                doneCooking = true;
                cooking = false;
                timerText.text = "Done!";
            }
        }

        if (doneCooking && playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // move into pizza box
            GameObject pizza = GameObject.FindWithTag("Pizza");

            pizza.transform.position = pizzaBox.transform.position;
            pizza.transform.rotation = pizzaBox.transform.rotation;
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
        cooking = true;

        timerText.gameObject.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pizzaInOven)
        {
            playerNearby = true;
            ovenPrompt.SetActive(true);
        }
        else if (other.CompareTag("Player") && doneCooking)
        {
            playerNearby = true;
            takeOutPrompt.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            ovenPrompt.SetActive(false);
            takeOutPrompt.SetActive(false);
        }
    }
}