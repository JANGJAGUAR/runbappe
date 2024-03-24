using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public GameObject gameOverPanel;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ENEMY")) // Enemy 태그를 가진 오브젝트와 충돌했는지 확인
        {
            Gameover();
        }
        if (other.CompareTag("WALL")) // Enemy 태그를 가진 오브젝트와 충돌했는지 확인
        {
            Gameover();
        }
    }
    void Gameover()
    {
        gameOverPanel = GameObject.Find("Canvas");
        gameOverPanel.GetComponent<GetCanvas>().GameOver();

        // 게임 정지
        Time.timeScale = 0f;
    }


}
