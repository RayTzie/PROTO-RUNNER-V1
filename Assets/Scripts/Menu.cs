using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject uiObjectMenuMain;

	// Use this for initialization
	void Start () {
		if(uiObjectMenuMain.activeSelf)
		{
			uiObjectMenuMain.SetActive (false); // Main Menu is invisible 
		}
		
	}
	
	// Update is called once per frame
	public void ShowCloseMenuMain () {
		if (uiObjectMenuMain.activeSelf) {
			uiObjectMenuMain.SetActive (false);
		} else {
			uiObjectMenuMain.SetActive (true);
		}
	}
}
