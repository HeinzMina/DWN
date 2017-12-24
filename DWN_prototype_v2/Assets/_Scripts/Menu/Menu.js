#pragma strict
import UnityEngine.UI;

var CameraObject : Animator;
var PanelSound : GameObject;
var PanelVideo : GameObject;
var PanelInstruction : GameObject;
var PanelAbout : GameObject;
//var hoverSound : GameObject;
//var sfxhoversound : GameObject;
//var clickSound : GameObject;
var areYouSure : GameObject;

//// campaign button sub menu
//var continueBtn : GameObject;
//var newGameBtn : GameObject;
//var loadGameBtn : GameObject;

//function PlayCampaign(){
//	areYouSure.gameObject.active = false;
//	continueBtn.gameObject.active = true;
//	newGameBtn.gameObject.active = true;
//	loadGameBtn.gameObject.active = true;
//}

//function DisablePlayCampaign(){
//	continueBtn.gameObject.active = false;
//	newGameBtn.gameObject.active = false;
//	loadGameBtn.gameObject.active = false;
//}

function Cam2(){
//    areYouSure.gameObject.active = false;
//	DisablePlayCampaign();
	CameraObject.SetFloat("Animate",0);
}

function Cam1(){
	CameraObject.SetFloat("Animate",1);
}

function Cam4(){
//    areYouSure.gameObject.active = false;
//	DisablePlayCampaign();
	CameraObject.SetFloat("Help",0);
}

function Cam3(){
	CameraObject.SetFloat("Help",1);
}

function SoundPanel(){
	PanelSound.gameObject.active = true;
	PanelVideo.gameObject.active = false;
}

function VideoPanel(){
	PanelSound.gameObject.active = false;
	PanelVideo.gameObject.active = true;
}

function InstructionPanel(){
	PanelInstruction.gameObject.active = true;
	PanelAbout.gameObject.active = false;
}

function AboutPanel(){
	PanelInstruction.gameObject.active = false;
	PanelAbout.gameObject.active = true;
}

//function PlayHover(){
//	hoverSound.GetComponent.<AudioSource>().Play();
//}

//function PlaySFXHover(){
//	sfxhoversound.GetComponent.<AudioSource>().Play();
//}

//function PlayClick(){
//	clickSound.GetComponent.<AudioSource>().Play();
//}

//function AreYouSure(){
//	areYouSure.gameObject.active = true;
//	DisablePlayCampaign();
//}

//function No(){
	//areYouSure.gameObject.active = false;
//}

function Yes(){
	Application.Quit();
}
