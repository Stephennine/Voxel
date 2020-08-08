using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom 
{
    public bool IsInit = false;
    /// <summary>
    /// 初始化力反馈设备
    /// </summary>
    /// <returns></returns>
    public bool Initial()
    {
        if (!IsInit)
        {
            if (Export.initial())
            {
                Export.setframe();
                Export.Enableforce();
                IsInit = true;
                Debug.Log("力反馈设备初始化成功");
                return true;
            }
            else
            {
                Debug.Log("力反馈设备初始化失败");
                return false;
            }
        }
        else
            return true;
    }

    public bool Stop()
    {
        if (IsInit)
        {
            if (Export.stop())
            {
                IsInit = false;
                Debug.Log("断开力反馈设备成功");
                return true;
            }
            else
            {
                Debug.Log("断开力反馈设备失败");
                return false;
            }

        }
        else
            return true;
    }
    Vector3 PhMax = new Vector3(208.4f, 141.5f, 123f);
    Vector3 PhMin = new Vector3(-207.6f, -70f, -64f);
    public Vector3 GetPos(Vector3 MyMax,Vector3 MyMin)
    {
        double[] pos = new double[3];
        Export.getpos(pos, 3);
        Vector3 Pos = new Vector3((float)pos[0], (float)pos[1], -(float)pos[2]);//转换成Vector3,且转换坐标系
        Pos = Divide(Multiply(Pos - PhMin, MyMax - MyMin), PhMax - PhMin) + MyMin;
        return Pos;
    }
    public void SetForce(Vector3 force)
    {
        double[] forcearray = new double[3] { force.x,force.y,-force.z};

        Export.Enableforce();
        Export.setforce(forcearray);
    }
    private Vector3 Multiply(Vector3 forward,Vector3 back)
    {
        return new Vector3(forward.x * back.x, forward.y * back.y, forward.z * back.z);
    }
    private Vector3 Divide(Vector3 forward, Vector3 back)
    {
        return new Vector3(forward.x / back.x, forward.y / back.y, forward.z / back.z);
    }
    
}
