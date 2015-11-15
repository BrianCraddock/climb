using UnityEngine;
using System.Collections;

public class MakePerson : MonoBehaviour {
	
	public GameObject player;

	void FixedUpdate () {
		if (Input.GetKeyDown ("space")) {
			CreatePerson();
		}
	}
	private void CreatePerson() {
		float h = -7;
		float v = -1;
		player.transform.position = new Vector2 (h, v);
		Instantiate (player);
	}
}
