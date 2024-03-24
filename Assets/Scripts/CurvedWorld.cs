using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedWorld : MonoBehaviour
{
    public Vector3 Curvature = new Vector3(0, 0.005f, 0);

    private int CurvatureID;
    private void OnEnable()
    {
        CurvatureID = Shader.PropertyToID("_Curvature");
    }

    void Update()
    {
        Shader.SetGlobalVector(CurvatureID, Curvature);
    }
}
