using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAgreement2D : MonoBehaviour {
    public Transform TargetObjet;
    Transform NowTrans;

    //---- 이미지 변경
    public Sprite[] Ball_Image;
    SpriteRenderer mSpriteRenderer;

    public float Image_ChangeDelayTime = 1;
    float imageChageTime = 0;
    int ImageIndex;
    //---- 이미지 변경

    // Use this for initialization
    void Start () {
        NowTrans = GetComponent<Transform>();

        mSpriteRenderer = GetComponent<SpriteRenderer>();
        if (Ball_Image.Length > 0)
            mSpriteRenderer.sprite = Ball_Image[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        NowTrans.position = TargetObjet.position;
        ImageChangeLogic();
    }

    void ImageChangeLogic()
    {

        if (Ball_Image.Length <= 0)
            return;
        if (imageChageTime < Time.time)
        {
            if (ImageIndex < Ball_Image.Length - 1)
                ImageIndex++;
            else
                ImageIndex = 0;

            mSpriteRenderer.sprite = Ball_Image[ImageIndex];
            imageChageTime = Time.time + Image_ChangeDelayTime;
        }
    }
}
