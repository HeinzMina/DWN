#pragma strict
import UnityEngine.UI;

// toggle buttons
var fullscreenOFF : GameObject;
var fullscreenON : GameObject;

var shadowoffOFF : GameObject;
var shadowoffON : GameObject;
var shadowlowOFF : GameObject;
var shadowlowON : GameObject;
var shadowhighOFF : GameObject;
var shadowhighON : GameObject;

var texturelowOFF : GameObject;
var texturelowON : GameObject;
var texturemedOFF : GameObject;
var texturemedON : GameObject;
var texturehighOFF : GameObject;
var texturehighON : GameObject;

// sliders
var musicSlider : GameObject;
var sfxSlider : GameObject;

var music : GameObject;
var sfx : GameObject;

private var sliderValue : float = 0.0;
private var sliderValueSFX : float = 0.0;

function Start () {
	// check slider values
	musicSlider.GetComponent.<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
	sfxSlider.GetComponent.<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
	
	music.GetComponent.<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	sfx.GetComponent.<AudioSource>().volume = PlayerPrefs.GetFloat("SFXVolume");

	// check full screen
	if(Screen.fullScreen == true){
		fullscreenON.SetActive(false);
		fullscreenOFF.SetActive(true);
	}
	else if(Screen.fullScreen == false){
		fullscreenON.SetActive(true);
		fullscreenOFF.SetActive(false);
	}

	// check shadow distance/enabled
	if(PlayerPrefs.GetInt("Shadows") == 0){
		QualitySettings.shadowCascades = 0;
		QualitySettings.shadowDistance = 0;
		shadowoffOFF.SetActive(false);
		shadowoffON.SetActive(true);
		shadowlowOFF.SetActive(true);
		shadowlowON.SetActive(false);
		shadowhighOFF.SetActive(true);
		shadowhighON.SetActive(false);
	}
	else if(PlayerPrefs.GetInt("Shadows") == 1){
		QualitySettings.shadowCascades = 2;
		QualitySettings.shadowDistance = 75;
		shadowoffOFF.SetActive(true);
		shadowoffON.SetActive(false);
		shadowlowOFF.SetActive(false);
		shadowlowON.SetActive(true);
		shadowhighOFF.SetActive(true);
		shadowhighON.SetActive(false);
	}
	else if(PlayerPrefs.GetInt("Shadows") == 2){
		QualitySettings.shadowCascades = 4;
		QualitySettings.shadowDistance = 500;
		shadowoffOFF.SetActive(true);
		shadowoffON.SetActive(false);
		shadowlowOFF.SetActive(true);
		shadowlowON.SetActive(false);
		shadowhighOFF.SetActive(false);
		shadowhighON.SetActive(true);
	}

	// check texture quality
	if(PlayerPrefs.GetInt("Textures") == 0){
		QualitySettings.masterTextureLimit = 2;
		texturelowOFF.SetActive(false);
		texturelowON.SetActive(true);
		texturemedOFF.SetActive(true);
		texturemedON.SetActive(false);
		texturehighOFF.SetActive(true);
		texturehighON.SetActive(false);
	}
	else if(PlayerPrefs.GetInt("Textures") == 1){
		QualitySettings.masterTextureLimit = 1;
		texturelowOFF.SetActive(true);
		texturelowON.SetActive(false);
		texturemedOFF.SetActive(false);
		texturemedON.SetActive(true);
		texturehighOFF.SetActive(true);
		texturehighON.SetActive(false);
	}
	else if(PlayerPrefs.GetInt("Textures") == 2){
		QualitySettings.masterTextureLimit = 0;
		texturelowOFF.SetActive(true);
		texturelowON.SetActive(false);
		texturemedOFF.SetActive(true);
		texturemedON.SetActive(false);
		texturehighOFF.SetActive(false);
		texturehighON.SetActive(true);
	}
}

function Update(){
	sliderValue = musicSlider.GetComponent.<Slider>().value;
	sliderValueSFX = sfxSlider.GetComponent.<Slider>().value;
	PlayerPrefs.SetFloat("MusicVolume", sliderValue);
	PlayerPrefs.SetFloat("SFXVolume", sliderValueSFX);
}

function FullScreen(){
	Screen.fullScreen = !Screen.fullScreen;

	if(Screen.fullScreen == true){
		fullscreenON.SetActive(true);
		fullscreenOFF.SetActive(false);
	}
	else if(Screen.fullScreen == false){
		fullscreenON.SetActive(false);
		fullscreenOFF.SetActive(true);
	}
}

function ShadowsOff(){
	PlayerPrefs.SetInt("Shadows",0);
	QualitySettings.shadowCascades = 0;
	QualitySettings.shadowDistance = 0;
	shadowoffOFF.SetActive(false);
	shadowoffON.SetActive(true);
	shadowlowOFF.SetActive(true);
	shadowlowON.SetActive(false);
	shadowhighOFF.SetActive(true);
	shadowhighON.SetActive(false);
}

function ShadowsLow(){
	PlayerPrefs.SetInt("Shadows",1);
	QualitySettings.shadowCascades = 2;
	QualitySettings.shadowDistance = 75;
	shadowoffOFF.SetActive(true);
	shadowoffON.SetActive(false);
	shadowlowOFF.SetActive(false);
	shadowlowON.SetActive(true);
	shadowhighOFF.SetActive(true);
	shadowhighON.SetActive(false);
}

function ShadowsHigh(){
	PlayerPrefs.SetInt("Shadows",2);
	QualitySettings.shadowCascades = 4;
	QualitySettings.shadowDistance = 500;
	shadowoffOFF.SetActive(true);
	shadowoffON.SetActive(false);
	shadowlowOFF.SetActive(true);
	shadowlowON.SetActive(false);
	shadowhighOFF.SetActive(false);
	shadowhighON.SetActive(true);
}

function TexturesLow(){
	PlayerPrefs.SetInt("Textures",0);
	QualitySettings.masterTextureLimit = 2;
	texturelowOFF.SetActive(false);
	texturelowON.SetActive(true);
	texturemedOFF.SetActive(true);
	texturemedON.SetActive(false);
	texturehighOFF.SetActive(true);
	texturehighON.SetActive(false);
}

function TexturesMed(){
	PlayerPrefs.SetInt("Textures",1);
	QualitySettings.masterTextureLimit = 1;
	texturelowOFF.SetActive(true);
	texturelowON.SetActive(false);
	texturemedOFF.SetActive(false);
	texturemedON.SetActive(true);
	texturehighOFF.SetActive(true);
	texturehighON.SetActive(false);
}

function TexturesHigh(){
	PlayerPrefs.SetInt("Textures",2);
	QualitySettings.masterTextureLimit = 0;
	texturelowOFF.SetActive(true);
	texturelowON.SetActive(false);
	texturemedOFF.SetActive(true);
	texturemedON.SetActive(false);
	texturehighOFF.SetActive(false);
	texturehighON.SetActive(true);
}