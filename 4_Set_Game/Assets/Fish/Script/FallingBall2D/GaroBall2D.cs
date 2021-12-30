using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GaroBall2D : MonoBehaviour {

    public enum MoveType
    {
        LEFT = 0,
        RIGHT,
        TOP,
        BOTTOM,
    };

    public GameObject BallObject;
    public MoveType mType = MoveType.RIGHT;

    public float CreatTime = 0.1f;
    public int BallMaxCount = 100;
    public int MaxXSize = 200;
    float TimeCheck = 0;

    public float BallShotPower = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        BallCreat();
    }

    void BallCreat()
    {
        if (Time.time <= TimeCheck)
            return;
        if (transform.childCount > BallMaxCount)
            return;

        Vector3 StartPosVec3;
        GameObject Ball;
        Rigidbody2D _rigidbody;
        Vector3 _shotDirection = Vector3.zero;

        StartPosVec3.x = 0;
        StartPosVec3.y = 0;
        StartPosVec3.z = 0;

        Ball = Instantiate(BallObject, transform.position, Quaternion.identity);
        Ball.transform.SetParent(transform);
        Ball.transform.localPosition = StartPosVec3;
        Ball.transform.localScale = new Vector3(5, 5, 5);//Vector3.one;
        _rigidbody = Ball.GetComponent<Rigidbody2D>();

        switch (mType)
        {
            case MoveType.LEFT:
                //_rigidbody.velocity = (Ball.transform.right * -1) * BallShotPower;
                _shotDirection = Ball.transform.right * -1;
                break;
            case MoveType.RIGHT:
                //_rigidbody.velocity = (Ball.transform.right) * BallShotPower;
                _shotDirection = Ball.transform.right;
                break;
            case MoveType.BOTTOM:
                //_rigidbody.velocity = (Ball.transform.up * -1) * BallShotPower;
                _shotDirection = Ball.transform.up * -1;
                break;
            case MoveType.TOP:
                //_rigidbody.velocity = (Ball.transform.up) * BallShotPower;
                _shotDirection = Ball.transform.up;
                break;
        }

        _rigidbody.velocity = _shotDirection * BallShotPower;
        TimeCheck = Time.time + CreatTime;
    }
}
