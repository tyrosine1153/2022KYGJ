using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingController : MonoBehaviour
{
    static string nextScene;
    public float L_Time = 1.6f;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadSceneAsync("Loading");
    }

    void Start() => StartCoroutine(LoadSceneProcess());

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return new WaitForSeconds(L_Time);

            op.allowSceneActivation = true;
        }
    }
}
