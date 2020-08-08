using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Colliinon_test : MonoBehaviour
{
    string caption = "";
    public bool isCol = false;
    GameObject CollsionObj;
    private void OnCollisionEnter(Collision collision)
    {
        caption = "enter";
        isCol = true;
        CollsionObj = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        caption = "exit";
        isCol = false;
        CollsionObj = null;
    }
    private void OnGUI()
    {
        GUIStyle gui_style = new GUIStyle();
        gui_style.fontSize = 15;
        GUI.Label(new Rect(20, 50, 200, 100), caption, gui_style);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Keypad4)) transform.Translate(new Vector3(-0.01f, 0.0f, 0.0f));
        if (Input.GetKey(KeyCode.Keypad6)) transform.Translate(new Vector3(0.01f, 0.0f, 0.0f));
        if (Input.GetKey(KeyCode.Keypad7)) transform.Translate(new Vector3(0.00f, 0.01f, 0.0f));
        if (Input.GetKey(KeyCode.Keypad9)) transform.Translate(new Vector3(0.0f, -0.01f, 0.0f));
        if (Input.GetKey(KeyCode.Keypad8)) transform.Translate(new Vector3(0.00f, 0.00f, 0.01f));
        if (Input.GetKey(KeyCode.Keypad5)) transform.Translate(new Vector3(0.0f, 0.00f, -0.01f));
        if (isCol)
        {
            Vector3 vec = transform.position - CollsionObj.transform.position;
            caption = vec.ToString("F3");
        }
    }
}
