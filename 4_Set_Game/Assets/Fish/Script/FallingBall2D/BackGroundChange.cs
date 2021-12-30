using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundChange : MonoBehaviour
{
    public SpriteRenderer NowBack;
    public SpriteRenderer NextBack;

    public Sprite[] ImageData;

    public float ShowDelay = 2;
    public float ChangeDelay = 1;
    float cDelay;

    int BgState = 0;
    int mIndex = 0;
    int MaxIndex = 0;
    float ColorA = 0;

    float CheckTime;

    // Use this for initialization
    void Start()
    {
        //float bgWidth = NowBack.GetComponent<BoxCollider2D>().size.x;
        //float bgHeight = NowBack.GetComponent<BoxCollider2D>().size.y;
        //float screenHeight = Camera.main.orthographicSize * 2;
        //float screenWidth = screenHeight * Camera.main.aspect;
        //float scaleRatioX = screenWidth / bgWidth;
        //float scaleRatioY = screenHeight / bgHeight;

        //transform.localScale = new Vector3(scaleRatioX, scaleRatioY, 1);

        BgState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (BgState)
        {
            case 0:
                MaxIndex = ImageData.Length;
                mIndex = 1;
                BgState = 1;
                CheckTime = Time.time + ShowDelay;
                break;
            case 1:
                if (CheckTime < Time.time)
                {
                    ColorA = 0;
                    BgState = 2;
                }
                break;
            case 2:
                cDelay = ChangeDelay * 0.01f;
                CheckTime = Time.time;
                BgState = 3;
                break;
            case 3:
                if (CheckTime < Time.time)
                {
                    NowBack.color = new Color(1, 1, 1, 1 - ColorA);
                    NextBack.color = new Color(1, 1, 1, ColorA);

                    ColorA += 0.01f;
                    if(ColorA > 1)
                        BgState = 4;

                    CheckTime = Time.time + cDelay;
                }
                break;
            case 4:
                CheckTime = 0;
                NowBack.sprite = NextBack.sprite;
                NextBack.sprite = ImageData[mIndex];

                NowBack.color = Color.white;
                NextBack.color = Color.white;

                mIndex++;
                if(mIndex >= ImageData.Length)
                {
                    mIndex = 0;
                }
                BgState = 5;
                break;
            case 5:
                CheckTime = Time.time + ShowDelay;
                BgState = 1;
                break;
        }
    }
    
}
