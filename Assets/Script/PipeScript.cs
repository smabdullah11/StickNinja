using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour {

	public static bool perfectBool;

	// Use this for initialization
	void OnEnable () {
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name.Contains("Building")) {
			
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name.Contains("Building")) {
			NinjaScript.enableStop = true;
		}

		if (coll.gameObject.name.Contains ("PerfrectPoint")) {
			perfectBool = true;
		}
	}
		
}
