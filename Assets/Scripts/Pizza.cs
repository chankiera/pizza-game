using UnityEngine;

public class Pizza : MonoBehaviour
{
    public GameObject FourSlices;
    public GameObject SixSlices;
    public GameObject EightSlices;

    private int slices;

    void Start()
    {
        slices = 0;
    }

    public void Slice()
    {
        if (!PizzaCutter.cutterSelected || slices == 8)
        {
            return;
        }

        if (slices == 0)
        {
            FourSlices.SetActive(true);
            slices = 4;
        }
        else if (slices == 4)
        {
            FourSlices.SetActive(false);
            SixSlices.SetActive(true);
            slices = 6;
        }
        else if (slices == 6)
        {
            SixSlices.SetActive(false);
            EightSlices.SetActive(true);
            slices = 8;
        }

        PizzaCutter.cutterSelected = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Pizza clicked");
        Slice();
    }
}
