using UnityEngine;

public class PizzaCutter : MonoBehaviour
{
    public static bool cutterSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cutterSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cutterSelected)
        {
            return;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Cutter selected");
        cutterSelected = true;
    }
}
