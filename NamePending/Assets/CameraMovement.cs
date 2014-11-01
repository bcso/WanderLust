using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	void Start ()
	{
		offset = transform.position;
	}

	void Update()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		transform.position = player.transform.position + offset;
	}
}
