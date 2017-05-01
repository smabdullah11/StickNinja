using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour {

	public GameObject[] background, city;

	// Use this for initialization
	void Start () {
		
	}


	void Update () {
		if (NinjaScript.startMovement) {
			for (int i = 0; i < city.Length; i++) {
				city [i].transform.Translate (Vector2.left * 0.0125f);
				background [i].transform.Translate (Vector2.left * 0.00625f);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name.Contains("Backgound")) {
			if (background [0].name == coll.gameObject.name) {
				background [0].transform.position = new Vector2 (background [1].transform.position.x + 65, -1.9f);
			} 
			else {
				background [1].transform.position = new Vector2 (background [0].transform.position.x + 65, -1.9f);
			}
		}
		if (coll.gameObject.name.Contains("City")) {
			if (city [0].name == coll.gameObject.name) {
				city [0].transform.position = new Vector2 (city [1].transform.position.x + 35, -2.33f);
			} 
			else {
				city [1].transform.position = new Vector2 (city [0].transform.position.x + 35, -2.33f);
			}
		}
	}
}
