using UnityEngine;
using UnityEngine.Networking;

public class CubeMove : NetworkBehaviour
{
	//public GameObject bulletPrefab;

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
	//[SerializeField]
	//Behaviour[]ComponentsToDisable;
	void Start () {
		
		if (isServer) {
			//Cardboard.SDK.VRModeEnabled = true;
			//Cardboard.SDK.enabled = false;
			//for (int i = 0; i < ComponentsToDisable.Length; i++) {
				//ComponentsToDisable [i].enabled = false;
			//}
		}
	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);

	}
}
