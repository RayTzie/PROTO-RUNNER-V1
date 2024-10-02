using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {
    public Pedals_Controller SpeedValue;
    public OverSpeeding SpeedometerValue;
    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;
    public Transmission_Controller TransmissionValue;
    private Transform needleTranform;
    private Transform speedLabelTemplateTransform;

    public float speedMax=200;
    public float speed;
    public bool isAccelerating;
    public float set_forward;

    public void Awake() {
        SpeedValue = GameObject.FindWithTag ("Pedals").GetComponent<Pedals_Controller>();
       //SpeedValue = GameObject.FindWithTag ("Player").GetComponent<OverSpeeding>();
        SpeedometerValue = GameObject.FindWithTag("Player").GetComponent<OverSpeeding>();
        needleTranform = transform.Find("needle");
        speedLabelTemplateTransform = transform.Find("speedLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);

        speed = 0f;
        speedMax = 200;

        CreateSpeedLabels();
    }

    public void Update() {
     
     // The speed value is return by speed variable from Pedals_Controller script.
     
    speed =SpeedometerValue.GetSpeed();
   

        //speed += 1000f * Time.deltaTime;
        //if (speed > speedMax) speed = speedMax;
        speed = Mathf.Clamp(speed, 0f, speedMax);
        needleTranform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    void Start () {
         TransmissionValue = GameObject.FindWithTag ("Transmission").GetComponent<Transmission_Controller>();
    }
    
    // On trigger event on Pointer Down 
    public void forward(){
        set_forward = TransmissionValue.GetTransmissionValue();
        //Debug.Log(TransmissionValue.GetTransmissionValue());
        if (set_forward==0){
            
           
        } 
        else if(set_forward==1){
             
        }
            else if(set_forward==2){
            
        }
            else if(set_forward==3){
           
         
          
            //Debug.Log("Accelerator Pedal is Pressed");
        }

    }

    public void CreateSpeedLabels() {
        int labelAmount = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for (int i = 0; i <= labelAmount; i++) {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmount;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle);
            speedLabelTransform.Find("speedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("speedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);
        }

        needleTranform.SetAsLastSibling();
    }

    public float GetSpeedRotation() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }

    public float GetSpeed(){
       return speed;
    }
}
