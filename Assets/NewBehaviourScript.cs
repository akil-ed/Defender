using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public float speed,minX,minY,maxX,maxY;
	// Use this for initialization
	void Start () {
		speed = Random.Range (0.1f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
		transform.Translate (Vector3.up * speed * Time.deltaTime);

		if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
			speed *= -1;
	}
}
