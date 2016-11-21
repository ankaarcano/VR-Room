using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CardboardRenderer :NetworkBehaviour {

	public GameObject Head;
	// Use this for initialization
	void Start () {
		if (isServer) {

			/*Renderer[] renderers = GetComponentsInChildren<Renderer> ();
			foreach (Renderer renderer in renderers) {
				renderer.enabled = false;
			}*/

		} else {
			//Camera.main.enabled = false;
			Camera[] cameras = GetComponentsInChildren<Camera> ();
			foreach (Camera camera in cameras) {
				camera.enabled = false;
				if(camera.name=="Main Camera"){
					
					Debug.Log ("zalazłam maina");
					
				}
			}
			GetComponent<CardboardReticle> ().enabled = false;
			//Head = transform.Find ("Head").gameObject;
			Head = GameObject.FindGameObjectWithTag("Head");
			Head.gameObject.SetActive (false);
			//Head.SetActive(false);



		}
	}

	// Update is called once per frame
	void Update () {

	}
}