using UnityEngine;

public class LightRayScanner : MonoBehaviour
{
    [Header("Scan Settings")]
    public float scanSpeed = 2f;
    public float scanAngle = 30f;

    [Header("Entity Detection")]
    public float rayLength = 10f;

    private bool isScanning = false;
    private Renderer beamRenderer;

    void Start()
    {
        beamRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isScanning = true;
            Scan();
            DetectEntity();
        }
        else
        {
            isScanning = false;
        }

        beamRenderer.enabled = isScanning;
    }

 void Scan()
{
    float angle = Mathf.Sin(Time.time * scanSpeed) * scanAngle;
    transform.localEulerAngles = new Vector3(0, 0, angle);
}

    void DetectEntity()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Entity"))
            {
                Debug.Log("Entity detected: " + hit.collider.name);
            }
        }
    }
}