using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureEnable : MonoBehaviour {

    //public RenderTexture none;
    public RenderTexture texture;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam.GetComponent<Texture>();
        
        Invoke("CamTexture", 1f);
    }

    // Update is called once per frame
    void CamTexture() {

        cam.targetTexture = texture;
    }
}
