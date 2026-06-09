using UnityEngine;

public class ToppingsStation : MonoBehaviour
{
    public GameObject enterPrompt;
    public GameObject fpsCamera;
    public GameObject pizzaCamera;
    public GameObject playerBody;
    public GameObject crossHair;
    public PlayerMovement playerMovement;
    public MouseBehavior mouseMovement;

    private bool playerNearby;
    private bool inPizzaMode;


    void Start()
    {
        inPizzaMode = false;
        EnterFPSMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (inPizzaMode && Input.GetKeyDown(KeyCode.E))
        {
            EnterFPSMode();
            inPizzaMode = false;
        }

        else if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            EnterPizzaMode();
            inPizzaMode = true;
        }
    }

    void EnterPizzaMode()
    {
        enterPrompt.SetActive(false);
        fpsCamera.SetActive(false);
        pizzaCamera.SetActive(true);
        playerMovement.enabled = false;
        mouseMovement.enabled = false;
        playerBody.SetActive(false);
        crossHair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void EnterFPSMode()
    {
        pizzaCamera.SetActive(false);
        fpsCamera.SetActive(true);
        playerMovement.enabled = true;
        mouseMovement.enabled = true;
        enterPrompt.SetActive(false);
        playerBody.SetActive(true);
        crossHair.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered");
            enterPrompt.SetActive(true);
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            enterPrompt.SetActive(false);
        }
    }
}
