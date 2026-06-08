using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunStation : MonoBehaviour
{
    public GameObject pickUpPrompt;
    public GameObject gun;
    public GameObject playerGun;

    private bool atGunStation;
    private bool holdingGun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atGunStation = false;
        holdingGun = false;
        gun.SetActive(true);
        playerGun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (atGunStation && !holdingGun && Input.GetKeyDown(KeyCode.F))
        {
            PickUpGun();
            holdingGun = true;
            pickUpPrompt.SetActive(false);
        }
        else if (atGunStation && holdingGun && Input.GetKeyDown(KeyCode.F))
        {
            DropGun();
            holdingGun = false;
            pickUpPrompt.SetActive(false);
        }
    }

    void PickUpGun()
    {
        gun.SetActive(false);
        playerGun.SetActive(true);
    }

    void DropGun()
    {
        gun.SetActive(true);
        playerGun.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpPrompt.SetActive(true);
            atGunStation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpPrompt.SetActive(false);
            atGunStation = false;
        }
    }
}
