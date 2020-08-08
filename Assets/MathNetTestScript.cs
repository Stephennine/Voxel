using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;

public class MathNetTestScript : MonoBehaviour
{
    Vector ght = DenseVector.Create(6, 0);
    public GameObject MoveObj;
    private void Awake()
    {
       // Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Matrix m1 = DenseMatrix.CreateIdentity(3);
        Debug.Log(m1.ToMatrixString());
        var m2 = m1 + 1;
        double[] newd = new double[9]
        {
            1,2,3,
            4,5,6,
            7,8,9
        };
        float alpha = 0.35f;
        double[] test = new double[9]
        {
            Mathf.Cos(alpha),Mathf.Sin(alpha),1,
            1,1,1,
            1,1,1
        };
        Matrix mm = new DenseMatrix(3,3,newd);
        Debug.Log(mm.ToMatrixString());
        var mmm = mm.PointwiseMultiply(m2);
        Debug.Log(mmm.ToMatrixString());

    }
    //int n = 0;
    //int fix_n = 0;
    // Update is called once per frame
    void Update()
    {
        //n++;
        //Debug.Log("Update " + n.ToString());
        ght = ToVector(MoveObj.transform.position, MoveObj.transform.rotation.eulerAngles);
        
    }
    private void FixedUpdate()
    {
        //fix_n++;
        //Debug.Log("FixUpdate " + fix_n.ToString());
    }
    private Vector ToVector(Vector3 pos,Vector3 euler)
    {
        Vector vec = DenseVector.Create(6, 0);
        for (int i = 0; i < 3; i++)
        {
            vec[i] = pos[i];
            vec[i + 3] = euler[i];
        }
        return vec;
    }
    private void OnGUI()
    {
        GUIStyle gui_style = new GUIStyle();
        gui_style.fontSize = 15;
        GUI.Label(new Rect(20, 50, 200, 100), ght.ToString("F4"), gui_style);
    }
}
