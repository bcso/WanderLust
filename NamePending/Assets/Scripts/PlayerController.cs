using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float turnSmoothing = 15f;
	public float speedDampTime =0.1f;

	public float ySpeed = 1.2f;
	public float xSpeed =0.0f;
	//float zPos = 0.0f;

	//float lastzPos = 0.0f;
	private float mouseX;
	private float mouseY;

	private Animator anim;
	private HashIDs hash;

	void Awake()
	{

		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
//		anim.SetLayerWeight (1, 1f);
	}
	

	void FixedUpdate()
	{

		if (Mathf.Abs (Skeleton.FootRightPos.z - Skeleton.FootLeftPos.z) > 5)
						xSpeed = 3;
		else if (Mathf.Abs (Skeleton.FootRightPos.z - Skeleton.FootLeftPos.z) > 3)
						xSpeed = 1;
		else
			xSpeed = 0;
		MovementManagement (xSpeed, 0);
	}

	void Update()
	{
		AudioManagement ();

		//Debug.Log ("Right Foot: " + (Skeleton.FootRightPos.z-startzPos));
	}

	void MovementManagement(float horizontal, float vertical)
	{
		if (horizontal != 0f || vertical != 0f) {
			Rotating (horizontal, vertical);
			anim.SetFloat (hash.speedFloat, horizontal ,speedDampTime, Time.deltaTime); 
		} 

		else
		{
			anim.SetFloat(hash.speedFloat, 0f, speedDampTime, Time.deltaTime); 
		}
	}

	void Rotating (float horizontal, float vertical)
	{
		Vector3 targetDirection = Camera.main.transform.forward;
		Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		rigidbody.MoveRotation (newRotation);
	}

	void AudioManagement()
	{
		if (!audio.isPlaying)
		{
			audio.Play();
		}

		else 
		{
			audio.Stop();
		}
	}
}

