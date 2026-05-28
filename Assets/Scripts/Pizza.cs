using UnityEngine;

public class Pizza : MonoBehaviour
{
    public GameObject sliceVisual;

    private bool sliced;

    void Start()
    {
        // sliceVisual.SetActive(false);
    }

    public void Slice()
    {
        if (!PizzaCutter.cutterSelected || sliced)
        {
            return;
        }

        sliced = true;
        sliceVisual.SetActive(true);
        PizzaCutter.cutterSelected = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Pizza clicked");
        Slice();
    }
}
