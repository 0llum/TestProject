using UnityEngine;
using System.Collections;

public class CarControllerMobile : MonoBehaviour {

	public float maxSpeed;
	public float rotationSpeed;
	public float acceleration;
	public float deceleration;

	private float currentSpeed;

	// Use this for initialization
	void Start () {
		Debug.Log (Screen.width);
		Debug.Log (Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if (currentSpeed < maxSpeed) {
				currentSpeed += Time.deltaTime * acceleration;
			} else {
				currentSpeed = maxSpeed;
			}

			if ((Input.touchCount > 1) && ((Input.GetTouch (0).position.x > Screen.width / 2 && Input.GetTouch (1).position.x < Screen.width / 2) ||
			    (Input.GetTouch (0).position.x < Screen.width / 2 && Input.GetTouch (1).position.x > Screen.width / 2))) {
				transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
			} else if (Input.GetTouch (0).position.x > Screen.width / 2) {
				transform.Rotate (Vector3.up * -Time.deltaTime * rotationSpeed * currentSpeed);
				transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
			} else {
				transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed * currentSpeed);
				transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
			}
		} else {
			if (currentSpeed > 0) {
				currentSpeed -= Time.deltaTime * deceleration;
			} else {
				currentSpeed = 0;
			}

			transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
		}
	}
}
