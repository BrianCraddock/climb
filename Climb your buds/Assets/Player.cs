using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool frozen = false;	
	private GameObject goal;

	// Use this for initialization
	void Start () {
		goal = GameObject.Find ("Goal Line");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if (!frozen) {
			Movement ();
			CheckHeight();

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

	private void CheckHeight() {
		var goalTop = goal.transform.position.y;
		foreach (Transform child in GetComponent<Transform>()) {
 			if (child.GetComponent<BoxCollider2D>() != null) {
				var playerTop = child.GetComponent<Transform>().position.y + child.GetComponent<BoxCollider2D>().bounds.extents.y;
				if (playerTop > goalTop) {		
					goalTop = playerTop;
					goal.transform.position = new Vector2(goal.transform.position.x, playerTop);
				}
			}
		}
	}
}
