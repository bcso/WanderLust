using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour {

		public static Vector3 HandLeftPos,
	HandRightPos,
	ElbowLeftPos,
	ElbowRightPos,
	KneeLeftPos,
	KneeRightPos,
	SpineMidPos,
	ShoulderLeftPos,
	ShoulderRightPos,
	FootLeftPos,
	FootRightPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandLeftPos = BodySourceView.HandLeftPos;
		HandRightPos = BodySourceView.HandRightPos;
		ElbowLeftPos = BodySourceView.ElbowLeftPos;
		ElbowRightPos = BodySourceView.ElbowRightPos;
		KneeLeftPos = BodySourceView.KneeLeftPos;
		KneeRightPos = BodySourceView.KneeRightPos;

		ShoulderLeftPos = BodySourceView.ShoulderLeftPos;
		ShoulderRightPos = BodySourceView.ShoulderRightPos;
		FootLeftPos = BodySourceView.FootLeftPos;
		FootRightPos = BodySourceView.FootRightPos;
		SpineMidPos = BodySourceView.SpineMidPos;
		Debug.Log ("SpineMid: " + SpineMidPos);
		Debug.Log ("ShoulderRight: " + ShoulderRightPos);
		Debug.Log ("HandRight: " + HandRightPos);

	}
}
