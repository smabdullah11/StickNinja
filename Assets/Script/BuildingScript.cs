using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name.Contains("GameManager")) {
			Destroy (transform.parent.gameObject);
		}
	}
}
