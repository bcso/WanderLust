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

	void FixedUpdate()
	{
//		Vector3 standardPosition = player.position + relCameraPosition;
//		Vector3 abovePosition = player.position + Vector3.up * relCameraMag;
//
//		Vector3[] checkPoints = Vector3 [5];
//
//		checkPoints [0] = standardPosition;
//		checkPoints [1] = Vector3.Lerp(standardPosition, abovePosition, 0.25f);
//		checkPoints [2] = Vector3.Lerp(standardPosition, abovePosition, 0.5f);
//		checkPoints [3] = Vector3.Lerp(standardPosition, abovePosition, 0.75f);
//		checkPoints [4] = abovePosition;
//
//		for (int i =0; i < checkPoints.Length; i++)
//		{
//			if(checkPosition(checkPoints[i]))
//				break;
//		}


		      
	}

	void Update()
	{
		transform.position = player.transform.position + relCameraPosition;
		relCameraPosition = transform.position - player.position;
		checkPosition (relCameraPosition);
	}

	void checkPosition(Vector3 checkVect)
	{
		RaycastHit hit;

		if (Physics.Raycast(checkVect, player.position - checkVect, out hit ,relCameraPosMag)){
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
