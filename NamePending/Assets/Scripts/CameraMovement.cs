using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public static Skeleton Skeleton;
	public Vector3 relCameraPosition;
	public float ySpeed = 2.2f;
	public float xSpeed = 2.0f;
	public GUIText debugText;
	public GameObject playerR;
	private HashIDs hash;
	private Animator anim;
	
	private Transform player;
	private GameObject hitGameObject;
	private Vector3 offset;
	//	private float relCameraPosMag; 
	private float mouseX;
	private float mouseY;
	private float h;
	private float v;
	private int count = 0;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		relCameraPosition = transform.position - player.position;
		//relCameraPosMag = relCameraPosition.magnitude - 0.5f;
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		Screen.lockCursor = true;
	}
	
	void Update()
	{
		Screen.showCursor = false;
		transform.position = player.transform.position + relCameraPosition;
		relCameraPosition = transform.position - player.position;
		if (Skeleton.HandRightPos.y > Skeleton.ElbowRightPos.y+1) //This will have to be the y value of knuckle joint from kinect deltavalue larger than.. --> boolean
		{
			debugText.text = "Count: " + count;
			checkTargetHit (transform.position);
		}
	}
	
	void LateUpdate()
	{
		Debug.Log (Vector3.Angle (Skeleton.HandRightPos, Skeleton.SpineMidPos));
		//if(Vector3.Angle (Skeleton.HandRightPos, Skeleton.SpineMidPos) > 25)
		//	mouseX += Skeleton.HandRightPos.x*.8f;
		//else
		mouseX += Skeleton.HandRightPos.x*.4f;
		//mouseY += Skeleton.HandRightPos.z;
		//Debug.Log (mouseX);//"Right Hand Y: " + Skeleton.HandRightPos.y);
		//mouseX += Input.GetAxis ("Mouse X"); //Wrist joint position vector float value (vector3), take vector3 .x component
		//mouseY -= Input.GetAxis ("Mouse Y") * ySpeed;

	//Vector3
		var rotation = Quaternion.Euler(0, mouseX, 0);
		//Vector3 playerRotation = new Vector3 (mouseY, 0.0f, 0.0f);

		transform.rotation = rotation;
		//playerR.rigidbody.AddForce (playerRotation);
	}
	
	void checkTargetHit(Vector3 checkPos)
	{
		RaycastHit hit;
		
		if (Physics.Raycast(checkPos, transform.forward, out hit)){
			if (hit.transform.tag == "Target")
			{
				anim.SetBool(hash.isShootingBool, true);
				debugText.text = "Score: " + ++count;
				Destroy(hit.transform.gameObject);
			}
		}
		
		
		
	}
}