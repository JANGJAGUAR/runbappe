using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCanvas : MonoBehaviour
{
    public GameObject curPlayer;
    public GameObject stp;
    public bool isGameOver;
    void Start()
    {
        isGameOver = false;
        // curPlayer = GameObject.FindWithTag("Player");
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        curPlayer = transform.Find("GameoverPanel").gameObject;
        curPlayer.SetActive(true);
        stp.GetComponent<ReSpawn>().isStart = false;
    }
}
