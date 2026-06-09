using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    public Light fireLight;
    public float intensityMin = 2f;
    public float intensityMax = 5f;
    public float speed = 10f;

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * speed, 0.0f);
        fireLight.intensity = Mathf.Lerp(intensityMin, intensityMax, noise);
    }
}