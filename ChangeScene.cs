using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "User") {
            StartCoroutine(NewSceneGame(sceneName));
        }
    }

    public IEnumerator NewSceneGame(string sceneName){
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            Debug.Log((progress * 100).ToString("n0") + "%");
            if(progress == 1f){
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
