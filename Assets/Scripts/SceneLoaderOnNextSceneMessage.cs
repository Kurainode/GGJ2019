using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderOnNextSceneMessage : MonoBehaviour
{
    public string nextSceneName;

    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
