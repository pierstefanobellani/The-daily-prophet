using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ColorCube : MonoBehaviour, IVirtualButtonEventHandler
{

    public Renderer targetCube;
    public GameObject buttonColor;

	// Use this for initialization
	void Start () {
        buttonColor = GameObject.Find("changeColor");
        buttonColor.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        targetCube.GetComponent<Renderer>();
	}
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        targetCube.material.SetColor("_Color", Color.red);
        Debug.Log("pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        targetCube.material.SetColor("_Color", Color.yellow);
        Debug.Log("released");
    }

}
