using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour {
	public Transform player;
	public GameObject[] waypoints;
	Animator anim;
	float rotSpeed = 1f;
	float speed = 3f;
	float accuracyWP = 1;
	int currentWP = 0;

	List<Transform> path = new List<Transform>();


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		currentWP = FindClosestWP();
		anim.SetBool("isRunning",true);
		anim.SetBool ("isidle", false);
	}

	void FillPath()
	{
		foreach (GameObject go in waypoints)
		{
			path.Add(go.transform);
		}
	}
	
	int FindClosestWP()
	{
		if(path.Count == 0)
		{
			FillPath();
		}
		int closest = 0;
		float lastDist = Vector3.Distance(this.transform.position, path[0].position);
		for(int i = 1; i < path.Count; i++)
		{
			float thisDist = Vector3.Distance(this.transform.position, path[i].position);
			if(lastDist > thisDist && i != currentWP)
			{
				closest = i;
			}
		}
		return closest;
	}

	void Update ()
	{
		Vector3 direction = path [currentWP].position - transform.position;
		this.transform.rotation = Quaternion.Slerp (transform.rotation,
			Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
		this.transform.Translate (0, 0, Time.deltaTime * speed);	
		if (direction.magnitude < accuracyWP) {
			path.Remove (path [currentWP]);
			currentWP = FindClosestWP ();
		}
	//}
//		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
		{

			direction.y = 0;

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
		}

	}
}

