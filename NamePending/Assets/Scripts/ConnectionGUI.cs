using UnityEngine;
public class ConnectionGUI : MonoBehaviour {
	public string serverIP = "127.0.0.1";
	public int serverPort = 7100;
	void OnGUI () {
		// Checking if you are connected to the server or not
		if (uLink.Network.peerType == uLink.NetworkPeerType.Disconnected)
		{
			// Show fields to insert ip address and port
			serverIP = GUI.TextField(new Rect(120,10,100,20),serverIP);
			serverPort = int.Parse(GUI.TextField(new
			                                     Rect(230,10,40,20),serverPort.ToString()));
			if (GUI.Button (new Rect(10,10,100,30),"Connect"))
			{
				//This code is run on the client
				uLink.Network.Connect(serverIP, serverPort);
				Debug.Log("Did send call to server");
			}
			if (GUI.Button (new Rect(10,50,100,30),"Start Server"))
			{
				//This code is run on the server
				uLink.Network.InitializeServer(32, serverPort);
			}
		}
		else
		{
			//This code is run when a connection is established
			string ipaddress = uLink.Network.player.ipAddress;
			string port = uLink.Network.player.port.ToString();
			GUI.Label(new Rect(140,20,250,40),"IP Adress: "+ipaddress+":"+port);
			if (uLink.Network.isServer)
				GUI.Label(new Rect(140,60,350,40),"Running as a server");
			else if (uLink.Network.isClient)
				GUI.Label(new Rect(140,60,350,40),"Running as a client");
			}
	}
	void uLink_OnServerInitialized() {
		Debug.Log("Server successfully started");
		Application.LoadLevel ("NamePendingEnvironment");
	}
	void uLink_OnConnectedToServer () {
		Debug.Log("Now connected to server");
		Debug.Log("Local Port = " + uLink.Network.player.port.ToString());
		Application.LoadLevel ("NamePendingEnvironment");
	}
	void uLink_OnPlayerDisconnected(uLink.NetworkPlayer player)
	{
		uLink.Network.DestroyPlayerObjects(player);
		uLink.Network.RemoveRPCs(player);
	}
	void uLink_OnFailedToConnect(uLink.NetworkConnectionError error)
	{
		Debug.LogError("uLink got error: "+ error);
	}
	void uLink_OnPlayerConnected(uLink.NetworkPlayer player) {
		Debug.Log("Player connected from " + player.ipAddress + ":" + player.port);
	}
}