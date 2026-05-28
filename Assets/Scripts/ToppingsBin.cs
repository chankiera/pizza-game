using UnityEngine;

public class ToppingsBin : MonoBehaviour
{
    public GameObject toppingsPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (HoldTopping.holdingTopping == true)
        {
            return;
        }
        Instantiate(toppingsPrefab, Camera.main.transform.position + Camera.main.transform.forward * 2f, Quaternion.identity);
    }
}
