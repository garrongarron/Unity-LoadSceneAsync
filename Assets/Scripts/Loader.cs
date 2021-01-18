using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    void Start()
    {
          
    }

    // Update is called once per frame
    public void Load2()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive));
        if(SceneManager.GetSceneByName("Scene3").isLoaded){
            SceneManager.UnloadSceneAsync("Scene3");
        }
    }
    public void Load3()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene3", LoadSceneMode.Additive));
        if(SceneManager.GetSceneByName("Scene2").isLoaded){
            SceneManager.UnloadSceneAsync("Scene2");
        }
        
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                Debug.Log(totalProgress/scenesToLoad.Count);
                yield return null;
            }
        }
    }
}
