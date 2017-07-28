using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour {
	public float speed;
	public float rotateConstant;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey (KeyCode.Mouse0)){
		//  Quaternion targetRotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y + (MouseHelper.mouseDelta.x),0);
		//	transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, speed*Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y + (MouseHelper.mouseDelta.x/rotateConstant),0);
			}
	}
}
