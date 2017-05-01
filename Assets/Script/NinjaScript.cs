using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaScript : MonoBehaviour {

	public GameObject building;

	public static bool startMovement, enableStop, shiftBuilding, enableTouch;
	public static int appleCount, buildingCount;

	bool localTouchHandler, flipBool;
	Collider2D flipCollider;
	SpriteRenderer ninjaSprite;

	float timeToActivate = 0;

	Animator anim;
	// Use this for initialization
	void Start () {
		startMovement = false;
		enableStop = false;
		enableTouch = true;
		shiftBuilding = false;
		localTouchHandler = false;
		flipBool = false;
		anim = transform.GetChild(0).GetComponent<Animator> ();
		flipCollider = transform.GetChild(0).GetComponent<Collider2D> ();
		ninjaSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.gameState == GameManager.GameState.inGame) {
			if (Input.GetMouseButtonDown (0)) {
				if (enableTouch) {
					building.transform.GetChild (1).gameObject.SetActive (true);
					building.transform.GetChild (2).gameObject.SetActive (false);
					localTouchHandler = true;
				} else if(flipBool) {
					ninjaSprite.flipY = !ninjaSprite.flipY;
					flipCollider.enabled = !flipCollider.enabled;
				}
			}

			if (Input.GetMouseButton (0)) {
				if (enableTouch && localTouchHandler) {
					building.transform.GetChild (1).localScale = new Vector3 (0.03f, building.transform.GetChild (1).localScale.y + 0.025f, 0.05f);
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				if (enableTouch && localTouchHandler) {
					building.transform.GetChild (1).GetComponent<Animator> ().SetInteger ("anim", 1);
					building.transform.GetChild (1).GetChild (0).localScale = new Vector3 (1, 0.03f / building.transform.GetChild (1).localScale.y, 1);
					Invoke ("ActivateWalk", 1);
					enableTouch = false;
					localTouchHandler = false;
					enableStop = false;
				}
			}

			if (startMovement) {
				transform.Translate (Vector2.right * 0.04f);
			}

		}
	}

	void ActivateWalk(){
		startMovement = true;
		timeToActivate = Time.timeSinceLevelLoad + 0.05f;
		anim.SetBool ("idle", false);
	}
		
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name.Contains ("Building")) {
			flipBool = false; 
			if (ninjaSprite.flipY) {
				GetComponent<Collider2D> ().isTrigger = true;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.name == "Stick") {
			if (!enableStop) {
				gameObject.GetComponent<Collider2D> ().isTrigger = true;
			}
		}

		if (coll.gameObject.name.Contains ("Building")) {
			flipBool = true;
		}
	}


	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.name.Contains ("GameManager")) {
			GameManager.gameState = GameManager.GameState.GameOver;
			startMovement = false;
		}	

		if (coll.gameObject.name == "EndPoint" && enableStop) {
			if (timeToActivate < Time.timeSinceLevelLoad && timeToActivate != 0) {
				startMovement = false;
				timeToActivate = 0;
				anim.SetBool ("idle", true);
				buildingCount++;
				flipBool = false;
			}
			building.transform.GetChild (1).GetComponent<Animator> ().SetInteger ("anim", 2);
			building.transform.GetChild (2).gameObject.SetActive (false);
			shiftBuilding = true;
			GameManager.generete = true;
		}
		if (coll.gameObject.name == "EndPoint" && !enableStop) {
//			gameObject.GetComponent<Collider2D> ().isTrigger = true;
		}

		if (coll.gameObject.name.Contains("apple")) {
			appleCount++;
			Destroy (coll.gameObject);
		}


	}

}
