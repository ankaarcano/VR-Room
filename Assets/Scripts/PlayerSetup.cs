using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
	

	[SerializeField]
	Behaviour[]ComponentsToDisable;
	public GameObject CardboardMainprefab;
	public Transform spawnPoint4;

	void Start () {
		if (!isLocalPlayer) {
			for (int i = 0; i < ComponentsToDisable.Length; i++) {
				ComponentsToDisable [i].enabled = false;
			}
		}

		if (isServer) {
			/*
			Camera.main.gameObject.SetActive (false);
			GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (true);
			*/
			//To było tutaj
			GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (false);
			Camera.main.gameObject.SetActive (true);
			Cardboard.SDK.VRModeEnabled = true;


		}
		else{
			//a to tutaj

			Camera.main.gameObject.SetActive (false);
			GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (true);

			//GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			//roomCam.gameObject.SetActive (true);
			//Camera.main.gameObject.SetActive (true);
			Cardboard.SDK.VRModeEnabled = false;

			}
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion rot = Cardboard.SDK.HeadPose.Orientation;
		//Vector3 pos = Cardboard.SDK.HeadPose.Position;
		//CmdSendCoordinates (pos, rot);
	}

	/*[Command]
	public void CmdSendCoordinates(Vector3 _direction, Quaternion _rotation){
		Vector3 direction = _direction;
		Quaternion rotation = _rotation;
		transform.Translate(rotation * direction);
	}*/
}

/*class MyManager : NetworkManager
{
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		//GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.Zero, Quaternion.Identity);
		//player.GetComponent<Player>().color = Color.Red;
		//NetworkServer.AddPlayerForConnection(conn, player, 0);
	}
	//ClientScene.AddPlayer(client.connection, 0);
}*/

	
