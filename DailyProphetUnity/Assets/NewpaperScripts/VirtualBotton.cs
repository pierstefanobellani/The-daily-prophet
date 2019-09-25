using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualBotton : MonoBehaviour, IVirtualButtonEventHandler
{
    [Header("Left page")]
    public Renderer UIPlaneLeft;

    public GameObject SwipeLeft;
    public GameObject Tap;
    public GameObject SavedLeft;

    [Space]
    public Material[] materialLeft;


    [Space]
    [Header("Right page")]
    public Renderer UIPlaneRight;

    public GameObject SwipeRight;
    public GameObject CloseArchived;
    public GameObject SavedRight;
    public GameObject Home;
    public GameObject Archive;

    [Space]
    public Material[] materialRight;

    [Space]
    [Header("Hints")]
    public Renderer tap;
    public Renderer saveL;
    public Renderer saveR;
    public Renderer close;

    public Material[] hintsMaterial;

    [Space]
    [Header("Variables")]
    public bool alreadyRead = false;
    public bool alreadySaved = false;




    void Start()
    {
        SwipeLeft = GameObject.Find("SwipeLeft");
        SwipeRight = GameObject.Find("SwipeRight");
        Home = GameObject.Find("Home");
        Archive = GameObject.Find("Archive");
        Tap = GameObject.Find("TapButton");
        CloseArchived = GameObject.Find("CloseArchived");
        SavedRight = GameObject.Find("SavedRight");
        SavedLeft = GameObject.Find("SavedLeft");

        SwipeLeft.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        SwipeRight.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Home.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Archive.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Tap.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        CloseArchived.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        SavedRight.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        SavedLeft.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        //cubeAnimator.GetComponent<Animator>();

        //prova UI Cate Newpaper
        UIPlaneLeft.GetComponent<Renderer>();
        UIPlaneLeft.sharedMaterial = materialLeft[0];

        UIPlaneRight.GetComponent<Renderer>();
        UIPlaneRight.sharedMaterial = materialRight[0];

    }

    private void Update()
    {
        //hints revoved
        if (UIPlaneLeft.sharedMaterial != materialLeft[0] && UIPlaneLeft.sharedMaterial != materialLeft[4])
        {
            tap.sharedMaterial = hintsMaterial[1];
        }
        else
        {
            tap.sharedMaterial = hintsMaterial[0];
        }
        if (UIPlaneLeft.sharedMaterial != materialLeft[2] && UIPlaneLeft.sharedMaterial != materialLeft[3] && UIPlaneLeft.sharedMaterial != materialLeft[7])
        {
            saveL.sharedMaterial = hintsMaterial[1];
        }
        else
        {
            saveL.sharedMaterial = hintsMaterial[0];
        }
        if (UIPlaneRight.sharedMaterial != materialRight[2] && UIPlaneRight.sharedMaterial != materialRight[3] && UIPlaneRight.sharedMaterial != materialRight[8] && UIPlaneRight.sharedMaterial != materialRight[9])
        {
            saveR.sharedMaterial = hintsMaterial[1];
        }
        else
        {
            saveR.sharedMaterial = hintsMaterial[0];
        }
        if (UIPlaneRight.sharedMaterial != materialRight[4] && UIPlaneRight.sharedMaterial != materialRight[5] && UIPlaneRight.sharedMaterial != materialRight[6] && UIPlaneRight.sharedMaterial != materialRight[7])
        {
            close.sharedMaterial = hintsMaterial[1];
        }
        else
        {
            close.sharedMaterial = hintsMaterial[0];
        }
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name == "SwipeLeft")
        {
            Debug.Log("previous");
            //prova UI Cate Newpaper
            PreviousPage();
        }
        else if (vb.name == "SwipeRight")
        {
            Debug.Log("next");
            NextPage();
        }
        else if (vb.name == "TapButton")
        {
            Article();
            //Debug.Log("TAP");
        }
        else if (vb.name == "CloseArchived")
        {
            Close();
            //Debug.Log("close");
        }
        else if (vb.name == "SavedLeft" || vb.name == "SavedRight")
        {
            Save();
            //Debug.Log("save");
        }
        else if (vb.name == "Home")
        {
            HomePage();
        }
        else if (vb.name == "Archive")
        {
            ArchivePage();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //Debug.Log("released");
        //cubeAnimator.Play("none");
    }

    public void NextPage()
    {
        //article has been read
        if (UIPlaneLeft.sharedMaterial == materialLeft[4] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[1];
            UIPlaneRight.sharedMaterial = materialRight[1];
        }

        //home navigation
        if (UIPlaneLeft.sharedMaterial == materialLeft[0] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            //Debug.Log("neeeext");
            UIPlaneLeft.sharedMaterial = materialLeft[1];
            UIPlaneRight.sharedMaterial = materialRight[1];
        }

        //article navigation
        else if (UIPlaneLeft.sharedMaterial == materialLeft[0] && UIPlaneRight.sharedMaterial == materialRight[2] || UIPlaneRight.sharedMaterial == materialRight[8] || UIPlaneLeft.sharedMaterial == materialLeft[4])
        {
            if (alreadySaved)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[2];
                UIPlaneRight.sharedMaterial = materialRight[9];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[2];
                UIPlaneRight.sharedMaterial = materialRight[3];
            }
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[2] && UIPlaneRight.sharedMaterial == materialRight[3] || UIPlaneRight.sharedMaterial == materialRight[9])
        {
            if (alreadySaved)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[7];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[3];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[3] && UIPlaneRight.sharedMaterial == materialRight[0] || UIPlaneLeft.sharedMaterial == materialLeft[7])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[4];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }

        //archive navigation
        else if (UIPlaneLeft.sharedMaterial == materialLeft[4] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[5];
            UIPlaneRight.sharedMaterial = materialRight[4];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[0] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[5];
            UIPlaneRight.sharedMaterial = materialRight[4];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[5] && UIPlaneRight.sharedMaterial == materialRight[4])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[6];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[5] && UIPlaneRight.sharedMaterial == materialRight[5])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[6];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[5] && UIPlaneRight.sharedMaterial == materialRight[6])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[6];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[5] && UIPlaneRight.sharedMaterial == materialRight[7])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[6];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[6] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            if (alreadyRead)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[4];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[0];
                UIPlaneRight.sharedMaterial = materialRight[0];
            } 
        }
    }

    public void PreviousPage()
    {
        //article has been read
        if (UIPlaneLeft.sharedMaterial == materialLeft[1] && UIPlaneRight.sharedMaterial == materialRight[1])
        {
            if (alreadyRead)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[4];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[0];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }   
        }

        //article navigation
        else if (UIPlaneLeft.sharedMaterial == materialLeft[3] && UIPlaneRight.sharedMaterial == materialRight[0] || UIPlaneLeft.sharedMaterial == materialLeft[7])
        {
            if (alreadySaved)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[2];
                UIPlaneRight.sharedMaterial = materialRight[9];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[2];
                UIPlaneRight.sharedMaterial = materialRight[3];
            }
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[2] && UIPlaneRight.sharedMaterial == materialRight[3] || UIPlaneRight.sharedMaterial == materialRight[9])
        {
            if (alreadySaved)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[0];
                UIPlaneRight.sharedMaterial = materialRight[8];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[0];
                UIPlaneRight.sharedMaterial = materialRight[2];
            }
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[0] && UIPlaneRight.sharedMaterial == materialRight[2] || UIPlaneRight.sharedMaterial == materialRight[8])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[0];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }

        //archive navigation
        else if (UIPlaneLeft.sharedMaterial == materialLeft[6] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[5];
            UIPlaneRight.sharedMaterial = materialRight[4];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[5] && UIPlaneRight.sharedMaterial == materialRight[4])
        {
            if (alreadyRead)
            {
                UIPlaneLeft.sharedMaterial = materialLeft[4];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
            else
            {
                UIPlaneLeft.sharedMaterial = materialLeft[0];
                UIPlaneRight.sharedMaterial = materialRight[0];
            }
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[0] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[5];
            UIPlaneRight.sharedMaterial = materialRight[4];
        }
        else if (UIPlaneLeft.sharedMaterial == materialLeft[4] && UIPlaneRight.sharedMaterial == materialRight[0])
        {
            UIPlaneLeft.sharedMaterial = materialLeft[5];
            UIPlaneRight.sharedMaterial = materialRight[4];
        }
    }

    public void Article()
    {
        alreadyRead = true;
        //Debug.Log("TAP");
        if (UIPlaneLeft.sharedMaterial == materialLeft[0] || UIPlaneLeft.sharedMaterial == materialLeft[4])
        {
            UIPlaneRight.sharedMaterial = materialRight[2];
        }
    }

    public void Close()
    {
        if (UIPlaneRight.sharedMaterial == materialRight[4])
        {
            UIPlaneRight.sharedMaterial = materialRight[5];
        }
        else if (UIPlaneRight.sharedMaterial == materialRight[5])
        {
            UIPlaneRight.sharedMaterial = materialRight[6];
        }
        else if (UIPlaneRight.sharedMaterial == materialRight[6])
        {
            UIPlaneRight.sharedMaterial = materialRight[7];
        }
    }

    public void Save()
    {
        if (!alreadySaved)
        {
            alreadySaved = true;

            if (UIPlaneRight.sharedMaterial == materialRight[2])
            {
                UIPlaneRight.sharedMaterial = materialRight[8];
            }
            else if (UIPlaneRight.sharedMaterial == materialRight[3])
            {
                UIPlaneRight.sharedMaterial = materialRight[9];
            }
            else if (UIPlaneLeft.sharedMaterial == materialLeft[3])
            {
                UIPlaneLeft.sharedMaterial = materialLeft[7];
            }
        }
        else
        {
            alreadySaved = false;
            if (UIPlaneRight.sharedMaterial == materialRight[8])
            {
                UIPlaneRight.sharedMaterial = materialRight[2];
            }
            else if (UIPlaneRight.sharedMaterial == materialRight[9])
            {
                UIPlaneRight.sharedMaterial = materialRight[3];
            }
            else if (UIPlaneLeft.sharedMaterial == materialLeft[7])
            {
                UIPlaneLeft.sharedMaterial = materialLeft[3];
            }
        }
    }

    public void HomePage()
    {
        if (alreadyRead)
        {
            UIPlaneLeft.sharedMaterial = materialLeft[4];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
        else
        {
            UIPlaneLeft.sharedMaterial = materialLeft[0];
            UIPlaneRight.sharedMaterial = materialRight[0];
        }
    }

    public void ArchivePage()
    {
        UIPlaneLeft.sharedMaterial = materialLeft[5];
        UIPlaneRight.sharedMaterial = materialRight[4];
    }
}