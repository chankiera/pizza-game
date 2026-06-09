using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipGun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UnequipAll();
        }
    }

    void EquipGun()
    {
        gun.SetActive(true);
    }

    void UnequipAll()
    {
        gun.SetActive(false);
    }
}
