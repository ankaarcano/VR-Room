﻿using UnityEngine;
using UnityEngine.Networking;

public class Host : MonoBehaviour {

	[SerializeField]
	private uint roomSize = 2;
	private string roomName;

	private NetworkManager networkManager;

	void Start()
	{
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null) {
			networkManager.StartMatchMaker ();
		}

	}

	public void SetRoomName (string _name){
		roomName = _name;
	}

	public void CreateRoom ()
	{
		if (roomName != "" && roomName != null) {
			
			networkManager.matchMaker.CreateMatch (roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
			Debug.Log("Creating Room: " + roomName + " with room for " + roomSize + " players.");
		}
	}
}
