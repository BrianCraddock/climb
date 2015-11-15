using UnityEngine;
using System.Collections;

public class GoalLine : MonoBehaviour {
	public float linePosition = (float)-0.43;
	// Use this for initialization
	void Start () {
	
	}
	
	
	void FixedUpdate () {
		var player = GameObject.Find ("Player(Clone)");
		if (player != null) {

			var playerTop = player.GetComponent<Transform> ().position.y;
			if (playerTop > linePosition) {

				linePosition = playerTop;		
				GetComponent<Transform> ().position = new Vector2 (0, linePosition);
			}
		}
	}
}