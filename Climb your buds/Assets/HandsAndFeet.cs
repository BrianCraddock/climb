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
			if (isStuck) {
				FreezeLimb();
			}
			isActive = false;
			GetComponent<SpriteRenderer> ().color = Color.red;
		}

		if (isActive) {			

			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");	


			if (h != 0 || v != 0) 
			{			
				var newX = GetComponent<Rigidbody2D>().position.x + (h * movementSpeed);
				var newY = GetComponent<Rigidbody2D>().position.y + (v * movementSpeed);
				GetComponent<Rigidbody2D>().MovePosition(new Vector2(newX, newY));
			}
		}
	}

	
	void OnCollisionEnter2D(Collision2D collision) {
		isStuck = true;
		FreezeLimb ();
	}

	private void FreezeLimb() {		
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
	}
}
