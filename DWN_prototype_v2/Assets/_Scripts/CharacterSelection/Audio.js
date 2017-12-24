#pragma strict
import UnityEngine.UI;

// sliders
var music : GameObject;
var sfx : GameObject;

function Start () {
	// check slider values
	music.GetComponent.<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	sfx.GetComponent.<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");
}