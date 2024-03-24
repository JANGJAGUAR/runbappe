using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Change : MonoBehaviour
{
    public GameObject backgroundPrefab, backgroundPrefab2;
    public int numberOfBackgrounds = 10; 
    public float backgroundDepth = 10f; 
    private GameObject player;
    private GameObject[] backgrounds;
    private float backmostBackgroundZ;
    
    public float changeTime;
    private float curTime;
    public int newBlocks;

    void Start()
    {
        curTime = 0f;
        newBlocks = 0;
        SpawnBackgrounds();
        ReSpawn reSpawn = FindObjectOfType<ReSpawn>();
        player = reSpawn.GetPlayer();
    }

    void Update()
    {
        //Debug.Log(curTime);
        curTime += Time.deltaTime;
        if (curTime >= changeTime)
        {
            if(player.transform.position.z > backmostBackgroundZ)
            {
                if (newBlocks < numberOfBackgrounds)
                {
                    NewMoveBack();
                    newBlocks++;
                }
                MoveBack();
            }
        }
        else
        {
            if(player.transform.position.z > backmostBackgroundZ)
            {
                MoveBack();
            }
        }
        
    }

    void SpawnBackgrounds()
    {
        backgrounds = new GameObject[numberOfBackgrounds];

        for(int i = 0; i < numberOfBackgrounds; i++)
        {
           
            GameObject background = Instantiate(backgroundPrefab, new Vector3(0, 0, i * backgroundDepth), Quaternion.identity);
            
            backgrounds[i] = background;
        }
        backmostBackgroundZ = backgrounds[2].transform.position.z;
        
    }

    void MoveBack()
    {
        GameObject backmostBackground = backgrounds[0];
        backmostBackground.transform.position = new Vector3(0, 0, backmostBackground.transform.position.z + numberOfBackgrounds * backgroundDepth);

        for (int i = 0; i < numberOfBackgrounds - 1; i++)
        {
            backgrounds[i] = backgrounds[i + 1];
        }
        backgrounds[numberOfBackgrounds - 1] = backmostBackground;
        backmostBackgroundZ = backgrounds[2].transform.position.z;

    }
    void NewMoveBack()
    {
        GameObject lastBG = backgrounds[0];
        GameObject newBG = Instantiate(backgroundPrefab2, new Vector3(0, 0, lastBG.transform.position.z), Quaternion.identity);
        backgrounds[0] = newBG;
    }

}

