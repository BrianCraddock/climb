using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool frozen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if (!frozen) {
			Movement ();

			if (Input.GetKeyDown ("space")) {
				Freeze ();
			}
		}
	}

	private void Movement () {		

		var camera = GameObject.Find ("Main Camera");
		var playerPosition = GetComponent<Rigidbody2D> ().position;

		camera.GetComponent<Transform> ().position = new Vector3(playerPosition.x, playerPosition.y, -10) ;
	}

	private void Freeze() {
		foreach (Transform child in GetComponent<Transform>()) {
			if (child.GetComponent<HandsAndFeet>() != null) {
				
				Destroy(child.GetComponent<HandsAndFeet>());
			}
		}
		var childrenJoints = GetComponentsInChildren<HingeJoint2D> ();
		var childrenRigidBodies = GetComponentsInChildren<Rigidbody2D> ();

		foreach(HingeJoint2D joint in childrenJoints) {
			Destroy(joint);
		}
		foreach (Rigidbody2D body in childrenRigidBodies) {
			Destroy(body);
		}
		frozen = true;
	}
}
