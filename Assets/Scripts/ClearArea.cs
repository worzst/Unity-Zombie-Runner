using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	public int obstacles = 0;
	private bool foundClearArea = false;
	
	// Update is called once per frame
	void Update() {
		if (obstacles <= 0 && Time.timeSinceLevelLoad > 10f && !foundClearArea) {
			SendMessageUpwards("OnFindClearArea");
			foundClearArea = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag != "Player") {
			obstacles--;
		}
	}
	void OnTriggerEnter(Collider col) {
		if (col.tag != "Player") {
			obstacles++;
		}
	}
}
