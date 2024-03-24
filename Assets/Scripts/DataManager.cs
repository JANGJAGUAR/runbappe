using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Halland, Kangin, Mbappe, Ronaldo, Sonny, No
    //순서대로 0~5를 가짐
}
public class DataManager : MonoBehaviour
{

    public GameObject[] players;
    public bool isChange;
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
        isChange = false;
    }

    public Character currentCharacter;
    public GameObject currentPlayer;

    private void Update()
    {
        // if (isChange)
        // {
        //     PlayerChange();
        //     isChange = false;
        // }
    }

    // private void PlayerChange()
    // {
    //     currentPlayer = players[(int)currentCharacter];
    // }
}
