using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Tooltip ("The parent of the spawn points")]
	public Transform playerSpawnPoints;
	public GameObject landingAreaPrefab;

	private bool reSpawn = false;
	private Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update() {
		if (reSpawn) {
			Respawn();
			reSpawn = false;
		}
	}

	private void Respawn() {
		int i = Random.Range(1, spawnPoints.Length);
		transform.position = spawnPoints[i].transform.position;
	}

	void OnFindClearArea() {
		Invoke ("DropFlare", 3f);
		// Deploy Flare
		// Start spawning Zombies
	}

	void DropFlare() {
		// Drop a flare
		Instantiate(landingAreaPrefab, transform.position, transform.rotation);
	}
}
