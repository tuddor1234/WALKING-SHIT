using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	public float speed = 6f;            

	Vector3 movement;                  
	Animator anim;                      
	Rigidbody playerRigidbody;          
	int floorMask;                      
	float camRayLength = 100f;   

	void Start () 
	{
		floorMask = LayerMask.GetMask ("Ground");

		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();

	}
	

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Move (h,v);
		Rotate ();
	//	Animating(h,v);
	}


	void Move(float h,float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);


	}

	void Rotate()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;


		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}

	}


	void Animating(float h,float v)
	{
		
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);

	}

}
