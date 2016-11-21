using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Disable : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (!isServer) {
			this.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
