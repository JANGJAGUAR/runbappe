using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Click : MonoBehaviour
{
    /*public void next()
    {
        SceneManager.LoadScene(1);
    }*/
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
