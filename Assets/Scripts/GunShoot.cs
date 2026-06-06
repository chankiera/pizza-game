using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private Animator gunAnimator;

    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunAnimator.Play("Take 001");
        }
    }
}