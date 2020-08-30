using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

    float deltaTime = 0.0f;

    string display = "{0} FPS";
    private Text m_Text;

    private void Start () {
        m_Text = GetComponent<Text> ();
    }

    private void Update () {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format ("{0:0.0} ms ({1:0.} fps)", msec, fps);

        m_Text.text = text;
    }
}