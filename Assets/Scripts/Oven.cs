using TMPro;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform pizzaSpot;
    public Transform pizzaTableSpot;
    public GameObject ovenPrompt;
    public GameObject takeOutPrompt;
    public GameObject pizzaBox;
    public float ovenTime;
    public TextMeshProUGUI timerText;

    private bool playerNearby;
    private PizzaState pizzaState = PizzaState.AtTable;
    private float remainingTime;
    private bool cooking;

    private enum PizzaState
    {
        AtTable,
        InOven,
        InBox
    }

    void Start()
    {
        ovenPrompt.SetActive(false);
        takeOutPrompt.SetActive(false);
        cooking = false;
        remainingTime = ovenTime;
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            switch (pizzaState)
            {
                case PizzaState.AtTable:
                    PutPizzaInOven();
                    break;
                case PizzaState.InOven when !cooking:
                    MovePizzaToBox();
                    break;
                case PizzaState.InBox:
                    ServeCustomerAndResetPizza();
                    break;
            }
        }

        if (cooking)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Cooking: " + Mathf.Ceil(remainingTime);

            if (remainingTime <= 0)
            {
                cooking = false;
                timerText.text = "Done!";
                takeOutPrompt.SetActive(true); // show "take out" prompt
            }
        }
    }

    void PutPizzaInOven()
    {
        GameObject pizza = GameObject.FindWithTag("Pizza");
        pizza.transform.position = pizzaSpot.position;
        pizza.transform.rotation = pizzaSpot.rotation;

        pizzaState = PizzaState.InOven;

        // RESET cooking state for new pizza
        cooking = true;
        remainingTime = ovenTime;      // reset timer
        timerText.gameObject.SetActive(true);

        ovenPrompt.SetActive(false);
        takeOutPrompt.SetActive(false); // hide "take out" until done
    }

    void MovePizzaToBox()
    {
        GameObject pizza = GameObject.FindWithTag("Pizza");
        pizza.transform.position = pizzaBox.transform.position;
        pizza.transform.rotation = pizzaBox.transform.rotation;

        pizzaState = PizzaState.InBox;
        takeOutPrompt.SetActive(true); // player can press E to serve
    }

    void ServeCustomerAndResetPizza()
    {
        GameObject pizza = GameObject.FindWithTag("Pizza");
        pizza.transform.position = pizzaTableSpot.position;
        pizza.transform.rotation = pizzaTableSpot.rotation;

        pizzaState = PizzaState.AtTable;
        takeOutPrompt.SetActive(false);
        timerText.gameObject.SetActive(false);

        // Serve customer
        Customer currentCustomer = FindObjectOfType<CustomerSpawner>()?.CurrentCustomer;
        if (currentCustomer != null)
            currentCustomer.ServeCustomer();

        // Show thank you dialogue
        DialogueController dialogueController = FindObjectOfType<DialogueController>();
        if (dialogueController != null)
            dialogueController.ShowMessage("Thank you!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = true;

        if (pizzaState == PizzaState.AtTable)
            ovenPrompt.SetActive(true);
        else if (pizzaState == PizzaState.InBox)
            takeOutPrompt.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerNearby = false;
        ovenPrompt.SetActive(false);
        takeOutPrompt.SetActive(false);
    }
}