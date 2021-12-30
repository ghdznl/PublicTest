using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall2D : MonoBehaviour {
    public GameObject BallObject;

    public float CreatTime = 0.1f;
    public int BallMaxCount = 100;
    public int MaxXSize = 200;
    float TimeCheck = 0;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        BallCreat();
    }

    void BallCreat()
    {
        if (Time.time <= TimeCheck)
            return;
        if (transform.childCount > BallMaxCount)
            return;

        int Random_0 = Random.Range(0, 100);
        int Random_1 = Random.Range(0, MaxXSize);

        float StartXPos = 0;
        Vector3 StartPosVec3;
        GameObject Ball;
        Rigidbody2D r2D;

        StartXPos = Random_1 * 0.1f;
        if (Random_0 < 50)
            StartXPos *= -1;

        StartPosVec3.x = StartXPos;
        StartPosVec3.y = 0;
        StartPosVec3.z = 0;

        Ball = Instantiate(BallObject);
        Ball.transform.SetParent(transform);
        Ball.transform.localPosition = StartPosVec3;
        Ball.transform.rotation = Quaternion.identity;
        Ball.transform.localScale = new Vector3(5, 5, 5);//Vector3.one;

        Ball.GetComponent<Rigidbody2D>().velocity = (Ball.transform.up * -1) * 0.01f;

        TimeCheck = Time.time + CreatTime;
    }
}
