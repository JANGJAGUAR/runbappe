using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    private GameObject player;
    private Animator player_anim;
    private Animator ball_anim;
    private GameObject mainCamera;
    public GameObject StartBtn;

    public bool isStart;
    

    void Awake()
    {
        player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
        for (int i = 0; i < charPrefabs.Length; i++)
        {
            Debug.Log("Index " + i + ": " + charPrefabs[i].name);
        }
        player.transform.position = transform.position;
        player_anim = player.GetComponent<Animator>();
        mainCamera = player.GetComponentInChildren<Camera>().gameObject;
        Transform ballTransform = player.transform.Find("Soccer Ball");
        if (ballTransform != null) // ball 오브젝트가 정말로 존재하는지 확인
        {
            ball_anim = ballTransform.GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("Ball object not found in player's children.");
        }
        
    }

    private void Start()
    {
        isStart = false;
    }

    private void Update()
    {
        if (!isStart) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    public void OnClickStartBtn()
    {
        isStart = true;
        player_anim.SetBool("isStart", true);
        StartBtn.SetActive(false);
        SkillAnim skillAnim = FindObjectOfType<SkillAnim>();
        if (skillAnim != null)
        {
            skillAnim.Initialize();
        }
        player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        mainCamera.transform.position = new Vector3(0, 5f, -8);
        // SceneManager.LoadScene("Scenes/GameScene");
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public Animator GetPlayerAnim()
    {
        return player_anim;
    }

    public Animator GetBallAnim()
    {
        return ball_anim;
    }
}
