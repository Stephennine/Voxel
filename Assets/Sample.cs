using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public ComputeShader compute;
    public Color color;
    public RenderTexture results;
    // Start is called before the first frame update
    void Start()
    {
        color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    private Color fix = new Color(0.5f, 0.6f, 0.7f, 1);
    // Update is called once per frame
    void Update()
    {
        int kernel = compute.FindKernel("CSMain");
        results = new RenderTexture(512, 512, 24);
        results.enableRandomWrite = true;
        results.Create();

        compute.SetTexture(kernel, "Result", results);
        color = fix * Mathf.Abs(Mathf.Sin(Time.time*10));
        Debug.Log(color.ToString());
        compute.SetVector("color", color);
        compute.Dispatch(kernel, 512 / 16, 512 / 16, 24);
    }
}
