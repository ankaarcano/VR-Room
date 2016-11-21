using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class follow : NetworkBehaviour {

	public GameObject catch_me;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Transform _head = catch_me.GetComponent<Transform> ();

		transform.position = _head.position;
		transform.rotation = _head.rotation;
		//Debug.Log ("Head transform position " + _head.position);
		//Debug.Log ("Head transform rotation " + _head.rotation);

	}
}

