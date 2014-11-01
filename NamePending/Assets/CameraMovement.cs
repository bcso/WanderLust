using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Vector3 relCameraPosition;


	private Transform player;
	private GameObject hitGameObject;
	private Vector3 offset;
	private float relCameraPosMag; 

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		relCameraPosition = transform.position - player.position;
		relCameraPosMag = relCameraPosition.magnitude - 0.5f;
	}
	
	void Update()
	{
		transform.position = player.transform.position + relCameraPosition;
		relCameraPosition = transform.position - player.position;
		checkPosition (relCameraPosition);
	}

	void checkPosition(Vector3 checkPos)
	{
		RaycastHit hit;

		if (Physics.Raycast(checkPos, player.position - checkPos, out hit ,relCameraPosMag)){
			if (hit.transform != player)
			{
				hitGameObject = hit.transform.gameObject;
				Color temp = Color.white;
				temp.a = 0.5f;

				hitGameObject.renderer.material.color = temp;
			}
			else
			{
				Color temp = Color.white;
				temp.a = 0.5f;
				hitGameObject.renderer.material.color = temp;
			}
		}



	}
}
