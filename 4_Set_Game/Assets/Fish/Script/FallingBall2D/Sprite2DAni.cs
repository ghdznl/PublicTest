using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite2DAni : MonoBehaviour {

    public Sprite[] Ball_Image;
    SpriteRenderer mSpriteRenderer;

    public float Image_ChangeDelayTime = 1;
    float imageChageTime = 0;
    int ImageIndex;

    // Use this for initialization
    void Start () {

        mSpriteRenderer = GetComponent<SpriteRenderer>();
        if (Ball_Image.Length > 0)
            mSpriteRenderer.sprite = Ball_Image[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
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
