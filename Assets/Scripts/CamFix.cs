using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CamFix : MonoBehaviour
{
    public int targetVerticalResolution = 1080;
    public float pixelsPerUnit = 100f;

    void Start()
    {
        Debug.Log("Screen: " + Screen.width + " x " + Screen.height);
        Debug.Log("Camera Size: " + Camera.main.orthographicSize);
        Camera cam = GetComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = targetVerticalResolution / (2f * pixelsPerUnit);
    }
}
