using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Export 
{
    [DllImport("phantom dll")]
    public static extern bool initial();//初始化设备

    [DllImport("phantom dll")]
    public static extern bool getbut();//获取按钮

    [DllImport("phantom dll")]
    public static extern int getpos([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] pos, int size);//获取设备位置

    [DllImport("phantom dll")]
    public static extern void setframe();//

    [DllImport("phantom dll")]
    // static extern void setforce([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]double[] force, int size);//设置力
    public static extern void setforce(double[] force);//设置力

    [DllImport("phantom dll")]
    public static extern int gettra([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] transform, int size);//获得旋转矩阵

    [DllImport("phantom dll")]
    public static extern bool stop(); //设备停止

    [DllImport("phantom dll")]
    public static extern bool Enableforce();//力反馈设备使能     

    [DllImport("phantom dll")]
    public static extern bool DisableForce();//力反馈设备不使能
}
