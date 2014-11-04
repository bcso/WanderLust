using UnityEngine;
using System.Collections;

public class PumpkinScript : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime*speed); 
	}
}
