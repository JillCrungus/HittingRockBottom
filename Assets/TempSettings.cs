using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TempSettings : NetworkBehaviour {


	Rect MusVolSliderPos = new Rect(new Vector2((Screen.width/2)-400, (Screen.height/2)-10), new Vector2(100, 100));
	Rect MusVolSliderLabel1Pos = new Rect(new Vector2((Screen.width/2)-400, Screen.height/2), new Vector2(100, 100));
	Rect MusVolSliderLabel2Pos = new Rect(new Vector2((Screen.width/2)-300, Screen.height/2), new Vector2(100, 100));
	Rect SfxVolSliderPos = new Rect(new Vector2((Screen.width/2)-400, (Screen.height/2)-100), new Vector2(100, 100));
	Rect SfxVolSliderLabel1Pos = new Rect(new Vector2((Screen.width/2)-400, (Screen.height/2)-100), new Vector2(100, 100));
	Rect SfxVolSliderLabel2Pos = new Rect(new Vector2((Screen.width/2)-300, (Screen.height/2)-100), new Vector2(100, 100));

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true; 
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name != "Menu_Network") {
			Destroy (this);
		}
	}

	void OnGUI() {
		float VolSlider = GUI.HorizontalSlider (MusVolSliderPos, PlayerPrefs.GetFloat("volume"), 0.0f, 1.0f);
		PlayerPrefs.SetFloat ("volume", VolSlider);
		float SfxSlider = GUI.HorizontalSlider (SfxVolSliderPos, PlayerPrefs.GetFloat ("sfxvolume"), 0.0f, 1.0f);
		PlayerPrefs.SetFloat ("sfxvolume", SfxSlider);

		GUI.Label (MusVolSliderLabel1Pos, "Music Volume: ");
		GUI.Label(MusVolSliderLabel2Pos, System.Math.Round(VolSlider, 2).ToString());

		GUI.Label (SfxVolSliderLabel1Pos, "SFX Volume: ");
		GUI.Label (SfxVolSliderLabel2Pos, System.Math.Round (SfxSlider, 2).ToString ());

	}
}
