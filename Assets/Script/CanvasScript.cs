using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour {

	public GameObject inGamePanel, gameOverPanel, helpText;
	public Text buildingCount, appleCount;
	public Animator perfectAnim;

	// Use this for initialization
	void Start () {
		NinjaScript.appleCount = PlayerPrefs.GetInt ("Apple");
		NinjaScript.buildingCount = 0;
		PipeScript.perfectBool = false;
		perfectAnim.Play ("PerfectAnim", 0, 1);
		Invoke ("HideHelp", 5);
	}
	
	// Update is called once per frame
	void Update () {
		switch ((int)GameManager.gameState) {
		case 0:
			{
				Time.timeScale = 1;
				appleCount.text = NinjaScript.appleCount + "";
				buildingCount.text = NinjaScript.buildingCount + "";
				gameOverPanel.SetActive (false);
				inGamePanel.SetActive (true);
				break;
			}

		case 1:
			{
				Time.timeScale = 0;
				gameOverPanel.SetActive (true);
				inGamePanel.SetActive (false);
				PlayerPrefs.SetInt ("Apple", NinjaScript.appleCount);
				break;
			}
		}	

		if (PipeScript.perfectBool) {
			perfectAnim.Play ("PerfectAnim", 0, 0);
			PipeScript.perfectBool = false;
		}
	}

	public void RestartBtn(){
		SceneManager.LoadScene (0);
	}

	void HideHelp(){
		helpText.SetActive (false);
	}

}
