using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientRenderer :NetworkBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioListener> ().enabled = false;
		if (isServer) {

			Camera[] cameras = GetComponentsInChildren<Camera> ();
			foreach (Camera camera in cameras) {
				camera.enabled = false;
			}
		} 
		else {
			//GameObject roomCam = GameObject.FindGameObjectWithTag("cam");
			//roomCam.gameObject.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
