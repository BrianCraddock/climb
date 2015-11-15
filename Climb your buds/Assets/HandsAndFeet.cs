using UnityEngine;
using System.Collections;

public class HandsAndFeet : MonoBehaviour {
	public bool isActive = false;	
	public bool isStuck = false;	
	public float movementSpeed = 5;  
	public string buttonKey;

	void Start () {
		foreach (Transform child in transform.parent) {
			if (child.GetComponent<Collider2D>() != null) {
				Physics2D.IgnoreCollision(child.GetComponent<Collider2D>(),GetComponent<Collider2D>());
			}
		}
	}

	void FixedUpdate () {

		if (Input.GetKey (buttonKey)) {
			isActive = true;
			isStuck = false;
			GetComponent<SpriteRenderer> ().color = Color.green;
		} else {		
			isActive = false;
			GetComponent<SpriteRenderer> ().color = Color.red;
		}

		if (isActive) {			
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");		
			GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * movementSpeed;
		}
	}

	
	void OnCollisionEnter2D(Collision2D collision) {
		isStuck = true;
		if (!isActive) {
			isStuck = true;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
		}
	}
}
