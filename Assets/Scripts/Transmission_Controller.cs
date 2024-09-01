using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class Transmission_Controller : MonoBehaviour {

	public Slider transmission_value;
	public int Current_value;
	
  
	// Use this for initialization
	void Start () {

		
		
	}


	// Update is called once per frame
	void Update () {
      
		//Debug.Log("Current Value is " + GetTransmissionValue());


	}

	public float GetTransmissionValue(){
		return transmission_value.value;
	}
}
