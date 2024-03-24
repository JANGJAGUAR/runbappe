using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCtrl : MonoBehaviour
{
    public float tackleTime;
    public float tackleDuration;
    private float currentTime;
    void Start()
    {
        currentTime = 0f;
    }
    float ratio;
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > tackleTime+tackleDuration)
        {
            ratio = Mathf.Lerp(ratio, 1.0f, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("ratio", ratio);
            anim.Play("tackle");
        }
        else if (currentTime > tackleTime)
        {
            ratio = Mathf.Lerp(ratio, 0.0f, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("ratio", ratio);
            anim.Play("tackle");
        }
        else
        {
            ratio = Mathf.Lerp(ratio, 1.0f, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("ratio", ratio);
            anim.Play("tackle");
        }
        
    }
}
