using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableARCamera : MonoBehaviour {
    public Camera realCamera;
    public Camera ARCamera;
    private bool cameraVisible = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraVisible)
        {
            realCamera.gameObject.SetActive(false);
            ARCamera.gameObject.SetActive(true);
            cameraVisible = false;
            Debug.Log("off");
        }
        else if (!cameraVisible)
        {
            realCamera.gameObject.SetActive(true);
            ARCamera.gameObject.SetActive(false);
            cameraVisible = true;
            Debug.Log("on");
        }
    }
}
