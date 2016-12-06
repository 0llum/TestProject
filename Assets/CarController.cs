using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float maxSpeed;
	public float rotationSpeed;
	public float acceleration;
	public float deceleration;

	private float currentSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey ("a") || Input.GetKey ("d")) {
            if (currentSpeed < maxSpeed) {
                currentSpeed += Time.deltaTime * acceleration;
            } else {
                currentSpeed = maxSpeed;
            }

            if (Input.GetKey ("a") && Input.GetKey ("d")) {
                transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
            } else if (Input.GetKey("d")) {
                transform.Rotate (Vector3.up * -Time.deltaTime * rotationSpeed * currentSpeed);
                transform.Translate (Vector3.forward * Time.deltaTime * currentSpeed);
            } else if (Input.GetKey ("a")) {
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
