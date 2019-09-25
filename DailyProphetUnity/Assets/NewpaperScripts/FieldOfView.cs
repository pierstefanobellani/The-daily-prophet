using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    public Camera foregroundCam;
    public Camera ARCamera;

	// Use this for initialization
	void Start () {
        foregroundCam.fieldOfView = 50f;

    }

    // Update is called once per frame
    void Update () {
        //foregroundCam.fieldOfView = ARCamera.fieldOfView;
        foregroundCam.fieldOfView = 50f;

    }
}
