//https://www.youtube.com/watch?v=c6NXkZWXHnc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraTexture : MonoBehaviour {

    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    //private int count;  //detect camera in scene, not hardware cameras

    
    //Use this for initialization ORIGINAL SCRIPT
    void Start () {

        //count = Camera.allCameras.Length;
        //print("We've got " + count + " cameras");

        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("no camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            //Debug.Log("Your cams: " + devices[i].name);
            if (devices[i].isFrontFacing)
            {
                Debug.Log("Your cams: " + devices[i].name);
            }

            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                Debug.Log("BACKCAM! " + devices[i].name);
            }
        }

        if (backCam == null)
        {
            Debug.Log("unable to find back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
