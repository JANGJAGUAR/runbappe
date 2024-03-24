using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ttr : MonoBehaviour
{
    public GameObject g0;
    public GameObject g1;
    public GameObject g2;

    //public ReSpawn respawnsp;
    //bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateImage(g0));
    }

    IEnumerator ActivateImage(GameObject go)
    {
        yield return null;
        go.SetActive(true);

    }

    public void UIoff(GameObject go)
    {
        go.SetActive(false);
        if (go == g0)
        {
            StartCoroutine(ActivateImage(g1));
        }
        else if (go == g1)
        {
            StartCoroutine(ActivateImage(g2));
        }
        else
        {

        }

    }

    public void ScenceChange()
    {
        SceneManager.LoadScene("Scenes/GameScene");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
