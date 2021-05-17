using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Points
{
    [SerializeField]
    public List<Vector3> points= new List<Vector3>();
}


[System.Serializable]
public class PointData
{

    [SerializeField]
    public List<float> times = new List<float>();
    [SerializeField]
    public List<Points> list = new List<Points>();

  
}
