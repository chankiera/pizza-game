using UnityEngine;

public class HoldTopping : MonoBehaviour
{
    public float height = 0.25f;
    public static bool holdingTopping = false;

    private Collider col;
    private Rigidbody rb;
    private bool canPlace = false;

    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>(); 
        col.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
        holdingTopping = true;

        Invoke(nameof(EnablePlacement), 0.1f);  // call function after .1 sec
    }

    void EnablePlacement()
    {
        canPlace = true;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // get pos of mouse with ray

        if (Physics.Raycast(ray, out RaycastHit hit))  // make topping follow mouse position
        {
            transform.position = hit.point + Vector3.up * height;
        }

        if (canPlace && Input.GetMouseButtonDown(0))  // clicking again makes you place/drop topping
        {
            holdingTopping = false;
            col.enabled = true;
            rb.isKinematic = false;
            rb.useGravity = true;
            Destroy(this);
        }
    }
}