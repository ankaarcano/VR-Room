using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CopyCardboard : NetworkBehaviour {

	public GameObject _cardboard;
	public GameObject _findCardboard;
	// Use this for initialization
	void Start () {
		Transform _head = _cardboard.GetComponent<Transform> ();

		transform.position = _head.position;
		//transform.rotation = _head.rotation;
		//Debug.Log ("Head transform position " + _head.position);
		Debug.Log ("Head transform rotation " + _head.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		//_findCardboard.FindWithTag ("CardboardMain");
		Cardboard[] cardboards = FindObjectsOfType<Cardboard>();
		foreach (Cardboard cardboard in cardboards)
		{ 
			//Debug.Log ("zanleziony cardboard: " + cardboard.name);
			Transform pozycja = cardboard.GetComponent<Transform>();
			transform.position = pozycja.position;
			//Debug.Log ("pozycja cardboarda: " + pozycja.position);

		}
		GameObject _HEAD = GameObject.FindGameObjectWithTag("Head");
		Transform obrot = _HEAD.gameObject.GetComponent<Transform> ();
		transform.rotation = obrot.rotation;
		//Debug.Log ("obrót heada: " + obrot.rotation);

	}
}
