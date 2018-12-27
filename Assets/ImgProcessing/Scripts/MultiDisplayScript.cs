using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;


[System.Serializable]
public class CameraPrefs
{
    public Camera camera;
    public Vector2 resolution;
}

public class MultiDisplayScript : MonoBehaviour {

    public List<CameraPrefs> cameras;
    Vector2 fRect;
    public Vector2 Position;
    void Awake() 
    {
        foreach (var cam in cameras) 
        {
            fRect.x += cam.resolution.x;
            if (cam.resolution.y > fRect.y)
                fRect.y = cam.resolution.y;
        }

        float buffer = 0;

        foreach (var cam in cameras) 
        {
            cam.camera.rect = new Rect(buffer, 1 - cam.resolution.y / fRect.y, cam.resolution.x / fRect.x, cam.resolution.y / fRect.y);
            buffer += cam.resolution.x / fRect.x; 
        }
    }

    void Start() 
    {
        #if UNITY_EDITOR
                return;
        #endif
        int handle = GetForegroundWindow();
        MoveWindow(handle, (int)Position.x, (int)Position.y, (int)fRect.x, (int)fRect.y, 1);
    }

    #region WinAPI
    [DllImport("user32.dll")]
    static extern int GetForegroundWindow();

    [DllImport("user32.dll", EntryPoint = "MoveWindow")]
    static extern int MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);
    #endregion
}
