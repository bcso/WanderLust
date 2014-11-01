using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Vector3 relCameraPosition;
	public float ySpeed = 1.2f;
	public float xSpeed = 1.0f;
	public GUIText debugText;
	public GameObject playerR;


	private Transform player;
	private GameObject hitGameObject;
	private Vector3 offset;
	//	private float relCameraPosMag; 
	private float mouseX;
	private float mouseY;
	private float h;
	private float v;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		relCameraPosition = transform.position - player.position;
		//		relCameraPosMag = relCameraPosition.magnitude - 0.5f;
	}
	
	void Update()
	{
		transform.position = player.transform.position + relCameraPosition;
		relCameraPosition = transform.position - player.position;
		if (Input.GetMouseButtonDown(0))
		{
			checkTargetHit (transform.position);
		}

		
		
		
	}
	
	void LateUpdate()
	{
		mouseX += Input.GetAxis ("Mouse X");
		mouseY -= Input.GetAxis ("Mouse Y") * ySpeed;


		

		var rotation = Quaternion.Euler(0, mouseX, 0);
		//Vector3 playerRotation = new Vector3 (mouseY, 0.0f, 0.0f);

		transform.rotation = rotation;
		//playerR.rigidbody.AddForce (playerRotation);
	}
	
	void checkTargetHit(Vector3 checkPos)
	{
		RaycastHit hit;
		
		if (Physics.Raycast(checkPos, Vector3.forward, out hit)){
			if (hit.transform.tag == "Target")
			{
				debugText.text = "Target hit!";
			}
		}
		
		
		
	}
}