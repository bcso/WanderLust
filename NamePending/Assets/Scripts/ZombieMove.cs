using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour {

	public GameObject player;
	public float turnSpeed = 2.0f;
	public float moveSpeed = 0.1f;

	private bool playerEntered;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{

			playerEntered = true;

		}
	}

	void Update()
	{
		if (playerEntered)
		{
			Quaternion oldRot = transform.rotation ;
			transform.LookAt ( player.transform, Vector3.up ) ;
			Quaternion newRot = transform.rotation ;
			transform.rotation = Quaternion.Lerp ( oldRot , newRot, turnSpeed * Time.deltaTime ) ;
			transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
//			transform.rotation = Vector3.Lerp(transform.rotation, player., Time*Time.deltaTime);
		}
	}

}
