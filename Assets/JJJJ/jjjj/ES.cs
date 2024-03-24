using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES : MonoBehaviour
{
    public float currTime;
    [SerializeField] private GameObject[] enemySet;
    private GameObject enemy1, enemy2, enemy3, enemy4;
    public float y;
    public float z;

    public float TkTime;
    public float tkDuration;
    public float coolTime;
    private int rd;
    private int rdLast;
    [SerializeField] private Transform Player;
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            enemySet[i].SetActive(true);

        }
        ReSpawn reSpawn = FindObjectOfType<ReSpawn>();
        Player = reSpawn.GetPlayer().transform;
    }

    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > 3)
        {

            rd = Random.Range(0, 9);
            while (rdLast == rd)
            {
                rd = Random.Range(0, 9);
            }
            rdLast = rd;

            if (rd == 0)        // ...
            {
                enemySet[1].transform.position = new Vector3(3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[5].transform.position = new Vector3(0f, y, z) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetSTK(enemySet[1], enemySet[5]));
            }
            else if (rd == 1)   // ...
            {
                enemySet[2].transform.position = new Vector3(3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[6].transform.position = new Vector3(0f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[7].transform.position = new Vector3(-3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);

                StartCoroutine(SetSTK(enemySet[2], enemySet[6]));
                StartCoroutine(SetSTK(enemySet[7]));
            }
            else if (rd == 2)   // ...
            {
                enemySet[3].transform.position = new Vector3(0f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[4].transform.position = new Vector3(-3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetSTK(enemySet[3], enemySet[4]));
            }
            else if (rd == 3)   // :
            {
                enemySet[8].transform.position = new Vector3(0f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[12].transform.position = new Vector3(0f, y, z + 5f) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetSTK(enemySet[8], enemySet[12]));
            }
            else if (rd == 4)   // :
            {
                enemySet[9].transform.position = new Vector3(3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[10].transform.position = new Vector3(3.5f, y, z + 5f) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetSTK(enemySet[9], (enemySet[10])));
            }
            else if (rd == 5)   // :
            {
                enemySet[7].transform.position = new Vector3(-3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                enemySet[11].transform.position = new Vector3(-3.5f, y, z + 5f) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetSTK(enemySet[7], enemySet[11]));
            }
            else if (rd == 6)   // T
            {
                enemySet[15].transform.position = new Vector3(0f, y, z) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetLTK(enemySet[15]));

            }
            else if (rd == 7)   // T
            {
                enemySet[13].transform.position = new Vector3(3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetLTK(enemySet[13]));
            }
            else if (rd == 8)   // T
            {
                enemySet[14].transform.position = new Vector3(-3.5f, y, z) + new Vector3(0f, 0f, Player.position.z);
                StartCoroutine(SetLTK(enemySet[14]));
            }
            currTime = 0;
            Debug.Log(rd);
        }
    }

    IEnumerator SetLTK(GameObject gO)
    {
        gO.GetComponent<Animator>().SetBool("LongTk", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        yield return new WaitForSeconds(TkTime);
        gO.GetComponent<Animator>().SetBool("LongTk", true);


        yield return new WaitForSeconds(tkDuration * 2);

        gO.GetComponent<Animator>().SetBool("LongTk", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
    IEnumerator SetSTK(GameObject gO)
    {
        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(TkTime);

        int bodyStk = Random.Range(0, 2);
        if (bodyStk == 1) gO.GetComponent<Animator>().SetBool("ShortTk", true);
        else gO.GetComponent<Animator>().SetBool("Body", true);


        yield return new WaitForSeconds(tkDuration);

        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    IEnumerator SetSTK(GameObject gO, GameObject g1)
    {
        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        g1.GetComponent<Animator>().SetBool("ShortTk", false);
        g1.GetComponent<Animator>().SetBool("Body", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(TkTime);
        int bodyStk = Random.Range(0, 2);
        if (bodyStk == 1) gO.GetComponent<Animator>().SetBool("ShortTk", true);
        else gO.GetComponent<Animator>().SetBool("Body", true);
        int bodyStk2 = Random.Range(0, 2);
        if (bodyStk2 == 1) g1.GetComponent<Animator>().SetBool("ShortTk", true);
        else g1.GetComponent<Animator>().SetBool("Body", true);


        yield return new WaitForSeconds(tkDuration);

        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        g1.GetComponent<Animator>().SetBool("ShortTk", false);
        g1.GetComponent<Animator>().SetBool("Body", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }
    IEnumerator SetSTK(GameObject gO, GameObject g1, GameObject g2)
    {
        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        g1.GetComponent<Animator>().SetBool("ShortTk", false);
        g1.GetComponent<Animator>().SetBool("Body", false);
        g2.GetComponent<Animator>().SetBool("ShortTk", false);
        g2.GetComponent<Animator>().SetBool("Body", false);

        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(TkTime);

        int bodyStk = Random.Range(0, 2);
        if (bodyStk == 1) gO.GetComponent<Animator>().SetBool("ShortTk", true);
        else gO.GetComponent<Animator>().SetBool("Body", true);
        int bodyStk2 = Random.Range(0, 2);
        if (bodyStk2 == 1) g1.GetComponent<Animator>().SetBool("ShortTk", true);
        else g1.GetComponent<Animator>().SetBool("Body", true);
        int bodyStk3 = Random.Range(0, 2);
        if (bodyStk3 == 1) g2.GetComponent<Animator>().SetBool("ShortTk", true);
        else g2.GetComponent<Animator>().SetBool("Body", true);

        yield return new WaitForSeconds(tkDuration);

        gO.GetComponent<Animator>().SetBool("ShortTk", false);
        gO.GetComponent<Animator>().SetBool("Body", false);
        g1.GetComponent<Animator>().SetBool("ShortTk", false);
        g1.GetComponent<Animator>().SetBool("Body", false);
        g2.GetComponent<Animator>().SetBool("ShortTk", false);
        g2.GetComponent<Animator>().SetBool("Body", false);
        gO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        g2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}
