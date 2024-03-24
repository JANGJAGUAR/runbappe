using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillAction : MonoBehaviour
{
    public float coolTime;
    public float currentTime;
    public bool coolReset;
    public Button sp;

    private Image currentImage;
    void Awake()
    {
        currentImage = GetComponent<Image>();
        currentTime = 0.0f;
        coolReset = false;

    }
    void Start()
    {
        // ���� GameObject�� �پ� �ִ� Button ������Ʈ�� �ڵ����� ã�Ƽ� �Ҵ�
        sp = GetComponent<Button>();
        sp.onClick.AddListener(DisableButton); // ��ư Ŭ�� �̺�Ʈ�� �޼ҵ� ����
        sp.interactable = false; // �ʱ⿡ ��ư ��Ȱ��ȭ
    }

    void Update()
    {
        //sp.interactable = false;

        if (coolReset)
        {
            currentTime = 0.0f;
            coolReset = false;
        }

        if (currentTime < coolTime)
        {
            currentTime += Time.deltaTime;
            currentImage.fillAmount = currentTime / coolTime;
            sp.interactable = false;
        }
        else if (sp.interactable == false) 
        {
            sp.interactable = true; 
        }


    }

    void DisableButton()
    {
        sp.interactable = false;
        coolReset = true;
    }
}
