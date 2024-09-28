using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarSound : MonoBehaviour
{
    AudioSource audioSource;
    public float maxPitch = 0.99f;
    public float minPitch = 0.2f;
    public float pitchFromCar;
    public Speedometer SpeedValue;
    public Speedometer MaxSpeedValue;

    // Start is called before the first frame update
    void Start()
    {
        // Check for Speedometer object before assigning
        GameObject speedometerObject = GameObject.FindWithTag("Speedometer");

        if (speedometerObject != null)
        {
            SpeedValue = speedometerObject.GetComponent<Speedometer>();
            MaxSpeedValue = speedometerObject.GetComponent<Speedometer>();
        }
        else
        {
            Debug.LogError("Speedometer object not found!");
        }

        // Check if AudioSource is attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject!");
        }
        else
        {
            audioSource.pitch = minPitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedValue == null || MaxSpeedValue == null || audioSource == null)
        {
            // Exit early if any required component is missing
            return;
        }

        float currentSpeed = SpeedValue.speed;
        float MaxSpeed = MaxSpeedValue.speedMax;

        float normalizedSpeed = Mathf.Clamp01(currentSpeed / MaxSpeed);
        pitchFromCar = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);

        // Set the pitch, ensuring it's within bounds
        audioSource.pitch = Mathf.Clamp(pitchFromCar, minPitch, maxPitch);
    }
}
