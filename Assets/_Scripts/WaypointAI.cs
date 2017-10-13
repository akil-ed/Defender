using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour {
	public Transform player;
	//public Transform head;
	//static Animator anim;
	//string state = "patrol";
	//public GameObject[] Waypoints;
	//int currentWP = 0;
	//public float rotspeed = 0.2f;
	//public float speed = 1.5f;
	//public float accuracyWP=5.0f;


	// Use this for initialization
	void Start () 
	{
		//anim.GetComponent<Animator> ();	
	}

	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (player.position, this.transform.position) < 10) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

		}
	}

}
/*anim.SetBool ("isIdle", false);
			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0, 0.5f);
				anim.SetBool ("isRunning", true);
				anim.SetBool ("isAttaking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isRunning", false);
			}
		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isAttaking", false);
		}
	}
}
		/*	Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, head.up);

		if (state == "patrol" && Waypoints.Length > 0)
		{
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isRunning", true);
			if (Vector3.Distance (Waypoints [currentWP].transform.position, transform.position) < accuracyWP)
			{
				currentWP++;
				if (currentWP >= Waypoints.Length) 
				{

					currentWP = 0;
				}

			}
//rotate towards waypoint
			direction = Waypoints[currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotspeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}
		if (Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing")) 
		{
		
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation(direction), rotspeed * Time.deltaTime);
			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isAttacking", false);
			} 
			else 
			{
				
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isRunning", false);

			}

		}
		else
		{
			anim.SetBool ("isRunning", true);
			anim.SetBool ("isAttaking", false);
			state = "patrol";
		
		}*/
		
