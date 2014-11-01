using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Vector3 relCameraPosition;
	public float ySpeed = 1.2f;
	public float xSpeed = 1.0f;
	public GUIText debugText;

	private Transform player;
	private GameObject hitGameObject;
	private Vector3 offset;
//	private float relCameraPosMag; 
	private float mouseX;
	private float mouseY;
	private int score= 0;


	void Awake ()
	{
		Screen.showCursor = false;
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		relCameraPosition = transform.position - player.position;
//		relCameraPosMag = relCameraPosition.magnitude - 0.5f;
	}
	
	void Update()
	{
		transform.position = player.transform.position + relCameraPosition;
		relCameraPosition = transform.position - player.position;
		player.LookAt(transform.forward);
		if (Input.GetMouseButtonDown(0))
		{
			checkTargetHit (transform.position);
		}
			

		
	}

	void LateUpdate()
	{
		mouseX += Input.GetAxis ("Mouse X");
		mouseY -= Input.GetAxis ("Mouse Y") * ySpeed;

		var rotation = Quaternion.Euler(mouseY, mouseX, 0);
//		var rotationR = new Vector3(mouseY, 0, 0);
//		var vectUp = Vector3.up;
//		player.rotation = Quaternion.LookRotation (rotationR);

		transform.rotation = rotation;

	}

	void checkTargetHit(Vector3 checkPos)
	{
		RaycastHit hit;

		if (Physics.Raycast(checkPos, transform.forward, out hit)){
			if (hit.transform.tag == "Target")
			{
				score++;
				debugText.text = "Score: " + score;
				Destroy(hit.transform.gameObject);
			}
		}



	}
}
