using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RayHit : NetworkBehaviour {
	
	private const int RIGHT_ANGLE = 90; 

	// This variable determinates if the player will move or not 
	private bool isWalking = false;
	private bool floor =false;
	private bool collision =false;
	private double thresholdAngle = 10;
	private float speed = 1;
	CardboardHead head = null;


	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		Debug.Log ("head coords " + head);
	}

	//void OnCollisionEnter(Collision col){
	void OnTriggerEnter(Collider col){
		switch (col.gameObject.name)
		{
		case "Room mesh":
			collision = true;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "Table_Big":
			collision =true;
			isWalking = false;
			Debug.Log ("Table");
			break;

		case "ściana001":
			collision =true;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "ściana002":
			collision =true;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "ściana003":
			collision =true;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "ściana004":
			collision =false;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "Book shelf":
			collision =true;
			isWalking = false;
			Debug.Log ("Walls");
			break;

		case "Chair (1)" : Debug.Log ("Chair");
			collision = true;
			isWalking = false;
			break;
		case "Old Leather Chair" : Debug.Log ("Fotel");
			collision = true;
			isWalking = false;
			break;
		}
	}

	//void OnCollisionExit(Collision col){
	void OnTriggerExit(Collider col){
		switch (col.gameObject.name)
		{
		case "Room mesh":
			collision = false;
			Debug.Log ("Walls");
			break;

		case "Table_Big":
			collision =false;
			Debug.Log ("Table");
			break;

		case "ściana001":
			collision =false;
			Debug.Log ("Walls");
			break;

		case "ściana002":
			collision =false;
			Debug.Log ("Walls");
			break;

		case "ściana003":
			collision =false;
			Debug.Log ("Walls");
			break;

		case "ściana004":
			collision =false;
			Debug.Log ("Walls");
			break;

		case "Book shelf":
			collision =false;
			Debug.Log ("Walls");
			break;

		case "Chair (1)" : Debug.Log ("Chair");
			collision =false;
			break;

		case "Old Leather Chair" : Debug.Log ("Fotel");
			collision =false;
			break;
		}
	}
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		if(isServer){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Quaternion rot = Cardboard.SDK.HeadPose.Orientation;
		//Vector3 pos = Cardboard.SDK.HeadPose.Position;
		//CmdSendCoordinates (pos, rot);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Floor") {
				floor = true;
			} else {
				floor = false;
			}
			if (floor && !isWalking && Cardboard.SDK.Triggered && !collision) {
				isWalking = true;
			} else if (collision || (isWalking &&
			         head.transform.eulerAngles.x >= thresholdAngle &&
			         (Cardboard.SDK.Triggered ||
			         head.transform.eulerAngles.x >= RIGHT_ANGLE))) {
				isWalking = false;
				collision = false; 
			}

			if (isWalking) {
				Vector3 direction = new Vector3 (head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
				Quaternion rotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
				// dodać jakiś warunek żeby nie wychodzić poza ściany i nie włazić na przedmioty

				RpcLookWalk (direction, rotation);
				//transform.Translate(rotation * direction);

				//Debug.Log ("direction :" + pos);//direction);
				//Debug.Log ("rotation :" + rot);//rotation);

				//CmdSendCoordinates(direction, rotation);
			}
		}
	}
	}
	[ClientRpc]
	public void RpcLookWalk(Vector3 _direction, Quaternion _rotation){
		transform.Translate(_rotation * _direction);
	}

	/*[Command]
	public void CmdSendCoordinates(Vector3 _direction, Quaternion _rotation){
		Vector3 direction = _direction;
		Quaternion rotation = _rotation;
		transform.Translate(rotation * direction);
	}*/
}
