using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	GameObject cameraObj;
	GameObject[] buildings;
	float distance;
	public static bool generete;
	public GameObject building;
	GameObject ninja;

	public enum GameState { inGame, GameOver};

	public static GameState gameState;
	public GameObject fruit;


	// Use this for initialization
	void Start () {
		cameraObj = FindObjectOfType<Camera> ().gameObject;
		buildings = GameObject.FindGameObjectsWithTag("Building");
		distance = 0;
		generete = false;
		ninja = FindObjectOfType<NinjaScript> ().gameObject;
		gameState = GameState.inGame;
	}
	
	// Update is called once per frame
	void Update () {
		if (NinjaScript.shiftBuilding) {
			buildings = GameObject.FindGameObjectsWithTag("Building");
//			distance = Mathf.Abs (buildings [0].transform.position.x - buildings [1].transform.position.x);
			if (generete) {
				Invoke ("DelayMovement", 0.5f);
				generete = false;
			}
		}
		cameraObj.transform.position = Vector3.MoveTowards (cameraObj.transform.position, new Vector3 (distance, 0, -10), 0.25f);
	}


	void DelayMovement(){
		if (buildings [0].transform.position.x > buildings [1].transform.position.x) {
			float x = Random.Range (3f, 5f);
			GameObject newBuilding = Instantiate (building, new Vector2 (buildings [0].transform.position.x + x, -7.27f), Quaternion.identity) as GameObject;
			float scaleX = Random.Range (0.3f, 0.8f);
			newBuilding.transform.GetChild(0).localScale = new Vector3 (scaleX, 2.5f, 1);
			newBuilding.transform.GetChild(1).localPosition = new Vector3 (1.375f * scaleX, 4.427f,0);
			newBuilding.transform.GetChild(2).localPosition = new Vector3 ( scaleX, 4.4258f,0);
			ninja.GetComponent<NinjaScript> ().building = buildings [0];
			distance = buildings [0].transform.position.x +2;
			if (Random.Range (0,10) > 3) {
				Instantiate (fruit, new Vector3 (Random.Range (buildings [0].transform.position.x + (scaleX * 3), buildings [0].transform.position.x + x - (scaleX * 3)), -3.82f, 0), Quaternion.identity);
			}
		} 
		else {
			float x = Random.Range (3f, 5f);
			GameObject newBuilding = Instantiate (building, new Vector2 (buildings [1].transform.position.x + x, -7.27f), Quaternion.identity) as GameObject;
			float scaleX = Random.Range (0.3f, 0.8f);
			newBuilding.transform.GetChild(0).localScale = new Vector3 (scaleX, 2.5f, 1);
			newBuilding.transform.GetChild(1).localPosition = new Vector3 (1.375f * scaleX, 4.427f,0);
			newBuilding.transform.GetChild(2).localPosition = new Vector3 ( scaleX, 4.4258f,0);
			ninja.GetComponent<NinjaScript> ().building = buildings [1];
			distance = buildings [1].transform.position.x +2;
			if (Random.Range (0,10) > 3) {
				Instantiate (fruit, new Vector3 (Random.Range (buildings [1].transform.position.x + (scaleX * 3), buildings [1].transform.position.x + x - (scaleX * 3)), -3.82f, 0), Quaternion.identity);
			}
		}
		EnableTouch ();
//		Invoke ("EnableTouch", 0.5f);
	}

	void EnableTouch(){
		NinjaScript.enableTouch = true;
	}

}
