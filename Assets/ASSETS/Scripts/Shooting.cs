using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {



	public float bulletSpeed = 60f;
	public float timeBetweenBullets = 0.15f;
	public GameObject bullet;

	float timer;
	Ray shootingRay;
	RaycastHit shootingHit;
	LayerMask shootableMask;
	float shootRange =100f;
	Vector3 offset = new Vector3(0,0.5f,0);
	 
	void Awake()
	{
		shootableMask = LayerMask.NameToLayer("Shootable");
	}


	void Update ()
	{
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && timer>timeBetweenBullets)	Shoot ();
		
	}

	void Shoot()
	{
		timer = 0f;
		shootingRay.origin = transform.position;
		shootingRay.direction = transform.forward;


		var bul =(GameObject) Instantiate (bullet, transform.position + offset, Quaternion.identity);
		bul.GetComponent<Rigidbody> ().velocity = transform.forward * 60f; 

		if (Physics.Raycast (shootingRay,out shootingHit,shootRange,shootableMask)) 
		{
			GameObject go = shootingHit.transform.gameObject;
			if (go)
			{

				ChangeMaterial cm = go.GetComponent<ChangeMaterial> ();
				if (cm)
					cm.Change ();
			}
			//Destroy (bul);

		}
		if(bul)Destroy (bul, 2f);
	}



}
