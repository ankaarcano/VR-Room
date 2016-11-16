using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class move : NetworkBehaviour {

	public float spinSpeed = 180f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (!isLocalPlayer)
			//return;

		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);
		transform.Rotate (Vector3.up, spinSpeed * Time.deltaTime);
	}
}
