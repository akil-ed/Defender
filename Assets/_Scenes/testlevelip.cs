using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testlevelip : MonoBehaviour {

	void Awake(){
		Application.targetFrameRate = 60;
	}
	// Use this for initialization
	void Start () {
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
