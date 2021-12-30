using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Ball2D : MonoBehaviour
{
    private Rigidbody2D _NowRigidBody;
    public Sprite[] Ball_Image;
    SpriteRenderer mSpriteRenderer;

    public byte BallState = 0;

    public Vector3 EndPos;
    float journeyLength = 0;

    public float Image_ChangeDelayTime = 1;
    float imageChageTime = 0;
    int ImageIndex = 0;

    // Use this for initialization
    void Start()
    {
        BallState = 0;
        _randomPowerCheckCount = Random.Range(10, 20);
        _NowRigidBody = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(name + " -- v : " + _NowRigidBody.velocity + " - vm : " + _NowRigidBody.velocity.magnitude);
        }
#endif
        Vector3 tempPos;
        switch (BallState)
        {
            case 0:
                if (_NowRigidBody.velocity.magnitude <= 7)
                {
                    Vector2 temp = _NowRigidBody.velocity;
                    temp *= 1.6f;
                    _NowRigidBody.velocity = temp;
                }
                if (_NowRigidBody.velocity.magnitude >= 12)
                {
                    Vector2 temp = _NowRigidBody.velocity;
                    temp *= 0.6f;
                    _NowRigidBody.velocity = temp;
                }
                break;
            case 1:
                _NowRigidBody.velocity = Vector2.zero;
                if (_NowRigidBody.velocity == Vector2.zero)
                    BallState = 2;
                //Destroy(GetComponent<Rigidbody2D>());
                break;
            case 2:
                journeyLength = Vector3.Distance(transform.position, EndPos);//시작과끝 위치 거리
                BallState = 3;
                break;
            case 3:
                tempPos = Vector3.Lerp(transform.position, EndPos, 1);
                transform.position = tempPos;
                break;
        }

        OverBallCheck();
    }

    private void FixedUpdate()
    {
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

    int _randomPowerCheckCount = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        _randomPowerCheckCount--;
        if (0 >= _randomPowerCheckCount)
        {
            ResetRandomPowerCheckCount();

            var rigidbodyNormalize = _NowRigidBody.velocity.normalized;
            var baseVec = Vector2.up;
            var dot = Vector2.Dot(Vector2.up, rigidbodyNormalize);
            if (0f > dot)
            {
                baseVec = Vector2.down;
            }

            float angle = Vector2.Angle(baseVec, rigidbodyNormalize);
            float changeAngle = Random.Range(angle - 50, angle + 50);
            if (1f > changeAngle)
            {
                changeAngle = 1f;
            }
            else if (85f < changeAngle)
            {
                changeAngle = 90;
            }

            Vector2 dir = Quaternion.Euler(0f, 0f, changeAngle) * baseVec;

            if (0f > _NowRigidBody.velocity.x && 0f < dir.x)
            {
                dir.x *= -1f;
            }
            else if (0f < _NowRigidBody.velocity.x && 0f > dir.x)
            {
                dir.x *= -1f;
            }

            var speed = (Random.Range(0.95f, 1.05f));
            _NowRigidBody.velocity = dir * speed;

            //_NowRigidBody.AddForce(transform.up * 3f);
        }
    }

    void ResetRandomPowerCheckCount()
    {
        _randomPowerCheckCount = Random.Range(20, 30);
    }

    void OverBallCheck()
    {
        bool destrotCheck = false;
        Vector3 nVec3 = transform.localPosition;
        if (nVec3.x < -200)
            destrotCheck = true;
        if (nVec3.x > 200)
            destrotCheck = true;
        if(nVec3.y < -200)
            destrotCheck = true;
        if (nVec3.y > 200)
            destrotCheck = true;

        if (destrotCheck)
            Destroy(gameObject);
    }
}
