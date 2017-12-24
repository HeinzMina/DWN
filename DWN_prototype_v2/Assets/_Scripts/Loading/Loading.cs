using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

   // public GameObject loading;
   // public GameObject buttons;
   public Slider slider;
   //public Text text;
    
   // int sceneIndex;

   // public void LoadingScrn(int sceneIndex)
   // {
   //     StartCoroutine(LoadScreen(sceneIndex));
   // }

   //IEnumerator LoadScreen(int sceneIndex)
   // {
   //     buttons.SetActive(false);
   //     loading.SetActive(true);
   //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
   //     operation.allowSceneActivation = false;

   //     while (!operation.isDone)
   //     {
   //         slider.value = operation.progress / 0.9f;
   //         text.text = operation.progress * 100f + "%";
   //         if (operation.progress == 0.9f)
   //         {
   //             slider.value = 1f;
                
   //             operation.allowSceneActivation = true;
   //         }
            
   //         yield return null;
   //     }
   // }

    float timeAmt = 0;
    float time;

    void Start()
    {
        time = timeAmt;
    }

    void Update()
    {
        if (time < 10)
        {
            //while (time < 10)
            //{
            time += Time.deltaTime;
            slider.value = time / 10;
            //text.text = time * 10 + "%";
        }
        else
        {
            Application.LoadLevel(2);
        }
    }

}
