using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class chase5 : MonoBehaviour {

	public Transform player;
	public Transform head;
	Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.2f;
	public float speed = 1.5f;
	public float accuracyWP = 5.0f;
	List<Transform> path =new List<Transform>();


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		foreach (GameObject go in waypoints) {
			path.Add (go.transform);
		}
		currentWP = FindClosestWP();
		anim.SetBool ("isWAlking", true);

	}
	int FindClosestWP()
	{
		if (path.Count == 0)
			return -1;
		int closest = 0;
		float lastDist = Vector3.Distance (this.transform.position, path [0].position);
		for(int i=1; i < path.Count; i++)
		{
			float thisDist = Vector3.Distance (this.transform.position, path [i].position);
			if(lastDist > thisDist && i != currentWP)
			{
				closest = i;
			}
		}
		return closest;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//Vector3 direction = player.position - this.transform.position;
		Vector3 direction = path [currentWP].position - transform.position;

		//direction.y = 0;
		float angle = Vector3.Angle(direction, head.up);
		
		if(state == "patrol" && waypoints.Length > 0)
		{
			anim.SetBool("isIdle",false);
			anim.SetBool("isWalking",true);
			//if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
			//{
				
				//currentWP = Random.Range(0,waypoints.Length);
				//currentWP++;
				//if(currentWP >= waypoints.Length)
				//{
				//	currentWP = 0;
				//}	
			//}
			
			//rotate towards waypoint
			direction = path[currentWP].position - transform.position;
			//this.transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
			//this.transform.Translate(0, 0, Time.deltaTime * speed);
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
			//if (direction.magnitude < accuracyWP) {
			if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
			{
			path.Remove (path [currentWP]);
				currentWP = FindClosestWP ();
			}
		}
		
		if(Vector3.Distance(player.position, this.transform.position) < 40 && (angle < 30 || state == "pursuing"))
		{
				
				state = "pursuing";
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
											Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

				if(direction.magnitude > 2)
				{
					this.transform.Translate(0,0,Time.deltaTime * speed);
					anim.SetBool("isWalking",true);
					anim.SetBool("isAttacking",false);
				}
				else
				{
					anim.SetBool("isAttacking",true);
					anim.SetBool("isWalking",false);
				}

		}
		else 
		{
			anim.SetBool("isWalking", true);
			anim.SetBool("isAttacking", false);
			state = "patrol";
		}

	}
}
