﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	private GameCamera cam;

	void Start () {
		cam = GetComponent<GameCamera>();
		SpawnPlayer(); 

	
	}
	private void SpawnPlayer() {
		cam.setTarget((Instantiate(player, Vector3.zero,Quaternion.identity) as GameObject).transform);
}
}