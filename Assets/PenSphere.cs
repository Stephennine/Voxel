using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;

public class PenSphere
{
    private Vector gtt;
    private List<SBB> balls;

    public Vector Gtt
    {
        get
        {
            return gtt;
        }
        set
        {
            gtt = value;
        }
    }
    public List<SBB> Spheres
    {
        get
        {
            return balls;
        }
        set
        {
            balls = value;
        }
    }

    public PenSphere()
    {
        gtt = DenseVector.Create(6, 0);
        balls = new List<SBB>();
    }
    public PenSphere(Vector g,List<SBB> bas)
    {
        gtt = g;
        balls = bas;
    }
    public List<SBB> GetSBB()
    {
        List<SBB> sbbs = new List<SBB>();
        foreach (var item in balls)
        {
            var pos = ToVector3;
            SBB newsbb = new SBB(pos + item.Center, item.Radius);
            sbbs.Add(newsbb);
        }
        return sbbs;
    }
    private Vector ToVector(Vector3 pos)
    {
        Vector vec = DenseVector.Create(6, 0);
        for (int i = 0; i < 3; i++)
            vec[i] = pos[i];           
        return vec;
    }
    public Vector3 ToVector3
    {
        get
        {
            Vector3 vec = Vector3.zero;
            for (int i = 0; i < 3; i++)
            {
                vec[i] = (float)gtt[i];
            }
            return vec;
        }
    }

}
