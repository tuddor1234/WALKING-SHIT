using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
	public Material start;
	public Material end; 
	public float speed = 5f;
	public bool done=false;

	Color c1,c2;

	float startTime;
	Color lerpedColor = Color.white;
	Material mat;

	void Start () 
	{
		mat = GetComponent<Renderer> ().material;
		startTime = Time.time;
		c1= start.color;
		c2 = end.color;
	}

	public void Change()
	{
		float t = (Time.time - startTime) * speed;

		lerpedColor = Color.Lerp (c1, c2, t);
		mat.color = lerpedColor;
		done = true;
	}

	/*
	void Update()
	{
		if (Input.GetKey (KeyCode.A) && !done) {
			float t = (Time.time - startTime) * speed;
			lerpedColor = Color.Lerp (c1, c2, t);
			mat.color = lerpedColor;
			done = true;
		}
	}
	*/

}
