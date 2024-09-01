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
    	SpeedValue = GameObject.FindWithTag ("Speedometer").GetComponent<Speedometer>();
    	MaxSpeedValue = GameObject.FindWithTag ("Speedometer").GetComponent<Speedometer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
        audioSource.pitch = maxPitch;
    }
 
    // Update is called once per frame
    void Update()
    {
        float currentSpeed = SpeedValue.speed;
        float MaxSpeed = MaxSpeedValue.speedMax;
        
        float normalizedSpeed = Mathf.Clamp01(currentSpeed/MaxSpeed);
        pitchFromCar = currentSpeed;
        pitchFromCar = Mathf.Lerp(minPitch,maxPitch,normalizedSpeed);

        if(pitchFromCar < minPitch)
            audioSource.pitch = minPitch;

        else
            
            audioSource.pitch = pitchFromCar; 
            //audioSource.pitch= Mathf.Clamp(minPitch, 0f, maxPitch);
    }
}