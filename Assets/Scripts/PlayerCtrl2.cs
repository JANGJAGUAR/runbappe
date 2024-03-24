using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2 : MonoBehaviour
{
    // public GameObject gameOverPanel;
    private Vector3 savedPosition;
    private float currentXPosition;
    private bool isPositionL = false;
    private bool isPositionM = false;
    private bool isPositionR = false;
    
    private Animator animator;
    public GameObject boostItem;
    private float fastDribbleTime = 0f;

    private bool isFastDribbling;

    private GameObject _ball;
    private void Start()
    {
        // 시간을 정상으로 복구
        Time.timeScale = 1f;
        isFastDribbling = false;
        boostItem = GameObject.FindWithTag("BOOST");
        animator = GetComponent<Animator>();
        _ball = GameObject.FindWithTag("BALL");
    }

    void Update()
    {
        currentXPosition = transform.position.x;
        if (isPositionL)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-3.5f, transform.position.y, transform.position.z), 0.01f);
            Debug.Log("왼쪽 정렬");
            StartCoroutine(Setfalse());
        }

        if (isPositionM)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.01f);
            Debug.Log("가운데 정렬");
            StartCoroutine(Setfalse());
        }

        if (isPositionR)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(3.5f, transform.position.y, transform.position.z), 0.01f);
            Debug.Log("오른쪽 정렬");
            StartCoroutine(Setfalse());
        }
        
        if (isFastDribbling)
        {
            //공 콜라이더 끄고
            _ball.SetActive(false);
            fastDribbleTime += Time.deltaTime;
            if (fastDribbleTime >= 3f)
            {
                //공 콜라이더 키고
                _ball.SetActive(true);
                animator.SetBool("IsFastDribble", false);
                fastDribbleTime = 0f;
                isFastDribbling = false;
            }
        }
    }

    IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(1f);
        isPositionL = false;
        isPositionM = false;
        isPositionR = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BOOST"))
        {
            boostItem.SetActive(false);
            animator.SetBool("IsFastDribble", true);
            isFastDribbling = true;
        }
    }


    // void Gameover()
    // {
    //     gameOverPanel = GameObject.Find("Canvas");
    //     gameOverPanel.GetComponent<GetCanvas>().GameOver();
    //
    //     // 게임 정지
    //     Time.timeScale = 0f;
    // }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void ResetPosition()
    {
        if (currentXPosition < -2)
        {
            isPositionL = true;
            Debug.Log("왼쪽true");
        }
        else if (-2 < currentXPosition && currentXPosition < 2)
        {
            isPositionM = true;
            Debug.Log("가운데true");
        }
        else if(currentXPosition > 2)
        {
            isPositionR = true;
            Debug.Log("오른true");
        }
    }
}