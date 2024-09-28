using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pedals_Controller : MonoBehaviour {

	public float speed;
	public float breakevalue;
	public float set_forward;
	public float transmission_State;
	public float m_GasUp;
	public float m_breakInput;
	public float m_gasInput;
	public float speedMax;
	public Transmission_Controller TransmissionValue;
	public AudioSource audioSource;
	public AudioClip soundToPlay;

	// Use this for initialization
	void Start () {
		 TransmissionValue = GameObject.FindWithTag ("Transmission").GetComponent<Transmission_Controller>();
	 	  speed = 0f;
	 	  breakevalue =0f;
          speedMax = 3000f;
	}
	
	// On trigger event on Pointer Down 
	public void forward(){
		set_forward = TransmissionValue.GetTransmissionValue();
		Debug.Log(TransmissionValue.GetTransmissionValue());
		if (set_forward==0){
			transmission_State = 1;
		} 
		else if(set_forward==1){
			transmission_State = 0;
			audioSource.Play();

		}
			else if(set_forward==2){
			transmission_State = -1;
		}
			else if(set_forward==3){
			transmission_State = 1;
			audioSource.Stop();
			//Debug.Log("Accelerator Pedal is Pressed");
		}

	}

	// On trigger event on Pointer Up 
	public void release(){
		transmission_State = 0f;
	}

	public float GetInputValue(){
		return m_GasUp;
	}

	public float GetBreakValue(){
		return breakevalue;
	}

	public float SpeedometerValue(){
		return speed;
	}

	public float BreakeValue(){
		return speed;
	}

	public void GetInput(){
		m_gasInput = GetInputValue();
	}

	public void GetBreakInput(){
		m_breakInput = GetBreakValue();
	}
	
	public void Accelerate(){
		speed += m_gasInput; // add time.delta if you want it very slow.
		speed = Mathf.Clamp(speed, 0f, speedMax);

	}

	public void Break(){
		breakevalue = breakevalue;
		breakevalue = Mathf.Clamp(breakevalue, 0f, breakevalue);
	}

	public void SpeedUp(){
		//Debug.Log("speed is increasing");

		
		m_GasUp = 1;
	}
	public void SpeedDown(){
		Debug.Log("speed is decreasing");
		Debug.Log("Reverse Pedal is Pressed");

		m_GasUp = -1;
	}

	public void Breakpress(){
	Debug.Log("Break Pedal is Pressed");	
     m_breakInput = 1;
     breakevalue = 200;
 
      
  	
	}
	public void Breakrelease(){
		
		m_breakInput = -1;
		breakevalue = 0;
		
	

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("The transmission is set to:" + set_forward);
	GetInput();
	Accelerate();
	Break();
	GetBreakInput();
	}

	public float GetAccelerator()
    {
        // returns moving state
        return transmission_State;
    }

    public float GetBreak()
    {
        // returns moving state
        return m_breakInput;
    }
}
