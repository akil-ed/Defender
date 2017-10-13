using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class chase4 : MonoBehaviour {

	public Transform player;
	public Transform head;
	static Animator anim;
	int currentWP = 0;
	public GameObject[] waypoints;
	string state = "patrol";
	bool pursuing = false;
	List<Transform> path =new List<Transform>();
	public float accuracyWP = 2f;



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
		Vector3 direction = path [currentWP].position - transform.position;
		//if (direction.magnitude < accuracyWP)
		if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
		{
			path.Remove (path [currentWP]);
			currentWP = FindClosestWP ();
		}
		direction = player.position - this.transform.position;
		//direction.y = 0;
		
		float angle = Vector3.Angle(direction, head.up);

		if(Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 30 || pursuing))
		{
			
			pursuing = true;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);

			anim.SetBool("isIdle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
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
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			pursuing = false;
		}

	}
}
