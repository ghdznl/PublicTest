using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomObject2D : MonoBehaviour {
    public GameObject Effect;
    public string ThouchTageName = "HandObj2D";
    public float ReSetTime = 2;

    //---- 이미지 변경
    public Sprite[] Ball_Image;
    SpriteRenderer mSpriteRenderer;

    public float Image_ChangeDelayTime = 1;
    float imageChageTime = 0;
    int ImageIndex;
    //---- 이미지 변경


    // Use this for initialization
    void Start ()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        if(Ball_Image.Length > 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(ThouchTageName))
        {
            Debug.Log("Hit Hand --- OnTriggerEnter2D");
            if (Effect != null)
            {
                GameObject eff = Instantiate(Effect, transform.position, Quaternion.identity);
                Destroy(eff, 2f);
            }
            //Destroy(gameObject);

            gameObject.SetActive(false);

            Invoke("mReSet", ReSetTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(ThouchTageName))
        {
            Debug.Log("Hit Hand --- OnCollisionEnter");
            if (Effect != null)
            {
                GameObject eff = Instantiate(Effect, transform.position, Quaternion.identity);
                Destroy(eff, 2f);
            }
            //Destroy(gameObject);

            gameObject.SetActive(false);

            Invoke("mReSet", ReSetTime);
        }
    }

    private void mReSet()
    {
        gameObject.SetActive(true);
    }
}
