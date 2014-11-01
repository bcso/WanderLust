﻿using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	
	public int speed = 10;
	
	private GameObject mainCamera;
	
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		
		Vector3 forceVect = new Vector3 (horizontal, 0.0f, vertical);
		
		rigidbody.AddForce (forceVect * speed);
	}
	
}