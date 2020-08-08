using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBB
{
    /// <summary>
    /// 包围盒球心
    /// </summary>
    public Vector3 Center { get; set; }
    /// <summary>
    /// 包围盒半径
    /// </summary>
    public float Radius { get; set; }
    
    public SBB(Vector3 center,float r)
    {
        Center = center;
        Radius = r;
    }
    public SBB()
    {
        Center = Vector3.zero;
        Radius = 0;
    }
    public bool IsCollied(SBB other)
    {
        float d2 = Vector3.Dot(Center, other.Center);//距离和的平方
        float r_t = Radius + other.Radius;

        if (d2 < r_t * r_t)
        {
            return true;
        }
        return false;
    }
    public Vector3 IsColliedVec(SBB other)
    {
        Vector3 dif = Center - other.Center;
        float r_t = Radius + other.Radius;

        return dif.normalized * (r_t - dif.magnitude);
    }
}
