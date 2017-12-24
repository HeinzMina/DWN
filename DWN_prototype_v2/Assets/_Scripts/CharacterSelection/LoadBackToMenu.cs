using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBackToMenu : MonoBehaviour {
	
	public AudioSource source;
	public AudioClip hover;
	public AudioClip click;

    public void LoadSceneNum(int num)
    {
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + num + ", SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings");
            return;
        }
        SceneManager.LoadScene(num);
    }
	
	public void onHover()
	{
		source.PlayOneShot(hover);
	}
	
	public void onClick()
	{
		source.PlayOneShot(click);
	}
}
