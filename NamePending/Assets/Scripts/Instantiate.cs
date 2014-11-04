using UnityEngine;
public class Instantiate : MonoBehaviour {
	public GameObject PlayerPrefab;
	public GameObject Camera;
	void Awake() {
		uLink.Network.Instantiate(PlayerPrefab, transform.position, transform.rotation, 0);
		Camera.SetActive (true);
		Debug.Log("Network aware game object is now created by client.");

	}
	void uLink_OnPlayerDisconnected(uLink.NetworkPlayer player)
	{
		Debug.Log ("wat");
		uLink.Network.DestroyPlayerObjects(player);
		uLink.Network.RemoveRPCs(player);
	}
}
