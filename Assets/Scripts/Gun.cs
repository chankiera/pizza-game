using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCamera;
    public float range = 10000f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shots fired!");
        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);
            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
