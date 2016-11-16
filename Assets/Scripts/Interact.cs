using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Collider))]
public class Interact : NetworkBehaviour, ICardboardGazeResponder {
	private Vector3 startingPosition;
	private Vector3 updatedPosition;
	//private Vector3 rotationVector= new Vector3(0f,5f,0f);
	//private Vector3 down = new Vector3 (100f, 0f, 0f);
	public float spinSpeed = 180f;
	//public bool spin;
	// Use this for initialization
	bool spin=false;
	void Start () {
		startingPosition = transform.localPosition;
		updatedPosition = transform.localPosition;
		RpcSetGazedAt(false);
		//SetGazedAt(false);
	}

	void LateUpdate() {
		Cardboard.SDK.UpdateState();
		if (Cardboard.SDK.BackButtonPressed) {
			Application.Quit();
		}
	}

	//[ClientRpc]
	public void //SetGazedAt(bool gazedAt) {
		RpcSetGazedAt(bool gazedAt) {
		
	}
	void Update () {
		if (spin == true) {
			//transform.Rotate (Vector3.up, spinSpeed * Time.deltaTime);
			RpcSpin();
			//Spin ();
		}
	}
	[ClientRpc]
	public void //MoveThingUp (){
		RpcMoveThingUp (){
			if (updatedPosition.y < 3.5f) {
				transform.position += new Vector3 (0f, 0.3f, 0f);
				updatedPosition = transform.position;
		}
	}
	[ClientRpc]
	public void RpcReset(){
		transform.localPosition = startingPosition;
	}
	[ClientRpc]
	public void //Spin(){
		RpcSpin(){
		transform.Rotate (Vector3.up, spinSpeed * Time.deltaTime);
	}

	public void ToggleDistortionCorrection() {
			Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.Unity;
			//break;
		//}
	}
	#region ICardboardGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see CardboardGaze).
	public void OnGazeEnter() {
		//SetGazedAt(true);
		RpcSetGazedAt(true);
		spin = true;
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		//SetGazedAt(true);
		RpcSetGazedAt(false);
		spin = false;
		//Reset ();
	}

	// Called when the Cardboard trigger is used, between OnGazeEnter
	/// and OnGazeExit.
	public void OnGazeTrigger() {
		RpcMoveThingUp ();
		//MoveThingUp ();
	}

	#endregion
}
