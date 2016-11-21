using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
	

	[SerializeField]
	Behaviour[]ComponentsToDisable;

	//public PlayerSetup PS;
	//public Transform spawnPoint4;

	void Start () {
		if (!isLocalPlayer) {
			for (int i = 0; i < ComponentsToDisable.Length; i++) {
				ComponentsToDisable [i].enabled = false;
			}
		}

		if (isServer) {

			/*Renderer[] renderers = HostCam.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in renderers)
			{ 
				renderer.enabled=false;
			}*/
			/*
			Camera.main.gameObject.SetActive (false);
			GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (true);
			*/
			//To było tutaj
			/*GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (false);
			Camera.main.gameObject.SetActive (true);
			Cardboard.SDK.VRModeEnabled = true;*/


		}
		else{
			//a to tutaj

			/*Camera.main.gameObject.SetActive (false);
			GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			roomCam.gameObject.SetActive (true);*/

			//GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			//roomCam.gameObject.SetActive (true);
			//Camera.main.gameObject.SetActive (true);
			//Cardboard.SDK.VRModeEnabled = false;
			/*Renderer[] renderers = MainCamera.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in renderers)
			{ 
				renderer.enabled=false;
			}*/

			}
	}
	
	// Update is called once per frame
	void Update () {
	}
}



	
