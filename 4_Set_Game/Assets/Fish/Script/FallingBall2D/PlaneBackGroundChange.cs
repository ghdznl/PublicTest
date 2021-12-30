using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBackGroundChange : MonoBehaviour {

    public MeshRenderer NowBack;

    public Material[] ImageData;

    int BgState = 0;

    public float ShowDelay = 120;
    float CheckTime;

    public int ShowIndex = 0;

    // Use this for initialization
    void Start()
    {
        BgState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (BgState)
        {
            case 0:
                CheckTime = Time.time + ShowDelay;
                BgState = 1;
                break;
            case 1:
                if (CheckTime < Time.time)
                {
                    ShowIndex++;
                    BgState = 2;
                }
                break;
            case 2:
                if(ShowIndex >= ImageData.Length)
                {
                    ShowIndex = 0;
                }
                NowBack.material = ImageData[ShowIndex];
                CheckTime = Time.time;
                BgState = 0;
                break;
        }
    }
}
