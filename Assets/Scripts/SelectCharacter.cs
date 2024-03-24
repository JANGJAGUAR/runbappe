using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] chrTrs;

    // private Character[] characters = {Halland, Kangin, Mbappe, Ronaldo, Sonny, No};
    private int _leftNum, _midNum, _rightNum;
    private Transform _leftTr, _midTr, _rightTr;
    public Transform _leftPos, _midPos, _rightPos;
    private Animator _animator;
    private bool isDance;

    void Start()
    {
        isDance = false;
        _leftNum = 4;
        _midNum = 0;
        _rightNum = 1;
        _rightTr = chrTrs[_rightNum].transform;
        _midTr = chrTrs[_midNum].transform;
        _leftTr = chrTrs[_leftNum].transform;
        _rightTr.position = _rightPos.position;
        _leftTr.position = _leftPos.position;
        _midTr.position = _midPos.position;


        DataManager.instance.currentCharacter = (Character)_midNum;
    }

    void Update()
    {
        if (isDance)
        {
            // Debug.Log(DataManager.instance.currentPlayer.GetComponent<Animator>().dance);
            chrTrs[_midNum].GetComponent<Animator>().SetBool("dance", true);
        }

    }

    public void LeftBtn()
    {
        StartCoroutine(LeftMove());
        _leftNum = _midNum;
        _midNum = _rightNum;
        _rightNum += 1;
        if (_rightNum == 5) _rightNum = 0;
        _rightTr = chrTrs[_rightNum].transform;
        _midTr = chrTrs[_midNum].transform;
        _leftTr = chrTrs[_leftNum].transform;
        _rightTr.position = _rightPos.position;
        // DataManager.instance.currentCharacter = (Character)_midNum;
        // DataManager.instance.isChange = true;
    }

    public void RightBtn()
    {
        StartCoroutine(RightMove());
        _rightNum = _midNum;
        _midNum = _leftNum;
        _leftNum -= 1;
        if (_leftNum == -1) _leftNum = 4;
        _rightTr = chrTrs[_rightNum].transform;
        _midTr = chrTrs[_midNum].transform;
        _leftTr = chrTrs[_leftNum].transform;
        _leftTr.position = _leftPos.position;
        // DataManager.instance.currentCharacter = (Character)_midNum;
        // DataManager.instance.isChange = true;
    }
    
    public void SelectBtn()
    {
        
        StartCoroutine(SelectButton());
    }
    IEnumerator SelectButton()
    {
        DataManager.instance.currentCharacter = (Character)_midNum;
        DataManager.instance.currentPlayer = DataManager.instance.players[_midNum];
        isDance = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scenes/Tutorial");
    }

    IEnumerator LeftMove()
    {
        _rightTr.position = Vector3.Lerp(_rightPos.position, _midPos.position, 1f);
        _midTr.position = Vector3.Lerp(_midPos.position, _leftPos.position, 1f);
        yield return null;
    }

    IEnumerator RightMove()
    {
        _midTr.position = Vector3.Lerp(_midPos.position, _rightPos.position, 1f);
        _leftTr.position = Vector3.Lerp(_leftPos.position, _midPos.position, 1f);
        yield return null;
    }
}