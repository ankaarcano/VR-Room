using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {
	
	public GameObject Fotelprefab;
	public GameObject Chairprefab;
	public GameObject Cardboardprefab;
	public GameObject Cameraprefab;
	public GameObject Cube;
	public GameObject Slup;

	public Transform spawnPoint1;
	//public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;

	public override void OnStartServer()
	{
		var fotel = (GameObject)Instantiate (Fotelprefab, spawnPoint1.position, spawnPoint1.rotation);
		var chair = (GameObject)Instantiate (Chairprefab, spawnPoint3.position, spawnPoint3.rotation);
		var cardboard = (GameObject)Instantiate (Cardboardprefab, spawnPoint4.position, spawnPoint4.rotation);
		var camera = (GameObject)Instantiate (Cameraprefab, spawnPoint4.position, spawnPoint4.rotation);
		var cube = (GameObject)Instantiate (Cube, spawnPoint4.position, spawnPoint4.rotation);
		var slup = (GameObject)Instantiate (Slup, spawnPoint4.position, spawnPoint4.rotation);

		slup.GetComponent<follow> ().catch_me = cube;
		camera.GetComponent<CopyCardboard> ()._cardboard = cardboard;


		NetworkServer.Spawn(fotel);
		NetworkServer.Spawn(chair);
		NetworkServer.Spawn(cardboard);
		NetworkServer.Spawn(camera);
		NetworkServer.Spawn(cube);
		NetworkServer.Spawn(slup);
	}

}
