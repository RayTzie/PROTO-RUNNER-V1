using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_Controller_V1 : MonoBehaviour {

	public GameObject target;

	public Touch touch;

	public Touch touchZoom;

	public float angleX;
	public float angleY;
	public float radius = 10;
	public float speed = 10;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 orbit = Vector3.forward * radius;
		orbit = Quaternion.Euler (angleY, angleX, 0) * orbit;
		transform.position = target.transform.position + orbit;
		transform.LookAt (target.transform.position);

		for (int i = 0; i < Input.touchCount; i++) {
			//Vector3 touchPosition = Camera.main.ScreenToWorldPoint (Input.touches[i].position);
			//Debug.DrawLine (Vector3.zero, touchPosition, Color.red);
			if (i == 0) {

				touch = Input.GetTouch (0);


				if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId)) {
					//Debug.Log ("Touched the UI");
					return;
				}



				if (touch.phase == TouchPhase.Moved) {


					float touchX = touch.deltaPosition.x;
					float touchY = touch.deltaPosition.y;


					angleX -= touchX * Time.deltaTime * speed ;
					angleY = Mathf.Clamp (angleY -= touchY * Time.deltaTime * speed, -89, 89);
					//radius = Mathf.Clamp (radius -= Input.mouseScrollDelta.y * speed  * Time.deltaTime, 2, 5);


					//transform.RotateAround (target.position, Vector3.up, touchY * speed * Time.deltaTime);
					//transform.RotateAround (target.position, transform.right, touchX * speed * Time.deltaTime); 
				}
				print ("You touch once!");
			}

			 if (i == 1) {
				touch = Input.GetTouch (0);
				touchZoom = Input.GetTouch (1);

				if (touchZoom.phase == TouchPhase.Moved) {

					Vector2 touchZeroPrevPos = touch.position - touch.deltaPosition;
					Vector2 touchOnePrevPos = touchZoom.position - touchZoom.deltaPosition;

					float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
					float currentMagnitude = (touch.position - touchZoom.position).magnitude;



					float touchZ = currentMagnitude - prevMagnitude;

					radius =  Mathf.Clamp (radius -= touchZ  * Time.deltaTime * speed/5, 2, 20);

				}
			}
			print ("You touch twice!");
		}
			
	}
}
