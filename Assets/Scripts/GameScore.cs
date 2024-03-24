using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public Score anotherScript;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        float score = anotherScript.GetScore();
        Text.text = "Game Score : " + Mathf.Round(score).ToString();

    }

}
