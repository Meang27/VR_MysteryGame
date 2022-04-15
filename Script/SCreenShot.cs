using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
public class SCreenShot : MonoBehaviour
{
    private static SCreenShot instance;
    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;

    public RawImage rawImg;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            rawImg.texture = renderTexture;
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width,int heigth)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, heigth, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width,int height)
    {
        instance.TakeScreenshot(width, height);
    }
}