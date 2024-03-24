using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAnim : MonoBehaviour
{
    //private GameObject gameOverPanel;
    private Animator animator_player;
    private Animator animator_ball;
    private GameObject boostItem;
    private bool isFastDribbling = false;
    private float fastDribbleTime = 0f;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("ENEMY")) // Enemy 태그를 가진 오브젝트와 충돌했는지 확인
    //    {
    //        Gameover();
    //        // 게임 오버 패널 활성화
    //        gameOverPanel.SetActive(true);
    //    }
    //}

    //private void Start()
    //{
    //    // 시간을 정상으로 복구
    //    Time.timeScale = 1f;
    //}

    public void Initialize()
    {
        ReSpawn reSpawn = FindObjectOfType<ReSpawn>();
        animator_player = reSpawn.GetPlayerAnim();
        animator_ball = reSpawn.GetBallAnim();
        boostItem = GameObject.FindWithTag("BOOST");
    }

    //void Gameover()
    //{
    //    gameOverPanel = GameObject.FindWithTag("GAMEOVERPANEL");
    //    // 게임 정지
    //    Time.timeScale = 0f;
    //}

    public void ChangePtTrigger()
    {
        animator_player.SetTrigger("isPt"); // Trigger 변경
        animator_ball.SetTrigger("isPt");
    }

    public void ChangeFfTrigger()
    {
        animator_player.SetTrigger("isFf"); // Trigger 변경
        animator_ball.SetTrigger("isFf");
    }

    public void ChangeJpTrigger()
    {
        animator_player.SetTrigger("isJp"); // Trigger 변경
        animator_ball.SetTrigger("isJp");
    }

    public void ChangeVdTrigger()
    {
        animator_player.SetTrigger("isVd"); // Trigger 변경
        animator_ball.SetTrigger("isVd");

    }

    public void ChangeMtTrigger()
    {
        animator_player.SetTrigger("isMt"); // Trigger 변경
        //animator_ball.SetTrigger("isMt");
    }

    public void ChangeSpTrigger()
    {
        animator_player.SetTrigger("isSp"); // Trigger 변경
        animator_ball.SetTrigger("isSp");
    }

    private void Update()
    {
        if (isFastDribbling)
        {
            fastDribbleTime += Time.deltaTime;
            if (fastDribbleTime >= 3f)
            {
                animator_player.SetBool("IsFastDribble", false);
                fastDribbleTime = 0f;
                isFastDribbling = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BOOST")
        {
            boostItem.SetActive(false);
            animator_player.SetBool("IsFastDribble", true);
            isFastDribbling = true;
        }
    }

    //public void ResetRotation()
    //{
    //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //}
}
