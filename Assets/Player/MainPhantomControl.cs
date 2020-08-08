using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPhantomControl : MonoBehaviour
{
    Phantom ph = new Phantom();
    double[] pos = new double[3];
    Vector3 Pos = Vector3.zero;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        ph.Initial();
    }

    // Update is called once per frame
    void Update()
    {
        if(ph.Initial())
        {
            Export.getpos(pos, 3);
            Pos = new Vector3((float)pos[0], (float)pos[1], -(float)pos[2]);
            obj.transform.position = Pos;
            if(Export.getbut())
            {
                Export.Enableforce();
                double[] force = new double[3] { 1.0, 1.0, 0.0 };
                Export.setforce(force);
            }
            else
            {
                double[] force = new double[3] { 0.0, 0.0, 0.0 };
                Export.setforce(force);
                Export.DisableForce(); 
            }

        }
    }
    private void OnDestroy()
    {
        ph.Stop();
    }
}
