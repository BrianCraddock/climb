using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float movementSpeed = 5;  
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
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");		
		var camera = GameObject.Find ("Main Camera");
		var playerPosition = GetComponent<Rigidbody2D> ().position;

		GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * movementSpeed;
		camera.GetComponent<Transform> ().position = new Vector3(playerPosition.x, playerPosition.y, -10) ;
	}

	private void Freeze() {
		var childrenJoints = GetComponentsInChildren<DistanceJoint2D> ();
		var childrenRigidBodies = GetComponentsInChildren<Rigidbody2D> ();
		var rigidBody = GetComponent<Rigidbody2D> ();

		foreach(DistanceJoint2D joint in childrenJoints) {
			Destroy(joint);
		}
		foreach (Rigidbody2D body in childrenRigidBodies) {
			Destroy(body);
		}
		frozen = true;
	}
}
