using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPizzaShop : MonoBehaviour
{
    public GameObject enterPrompt;
    private bool playerNearby = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("PizzaTime");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            enterPrompt.SetActive(true);
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
