using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove_2 : MonoBehaviour
{
    public Transform MoveEndTrans;
    Vector2 EndPos = Vector2.zero;

    public Material[] FishMaterial;
    public Transform MaterialTrans;

    public float GaroHalfSize = 8;
    public float SeroHalfSize = 5;
    
    public float MoveSpeed = 0.01f;
    int MoveState = 1;

    float digree;
    float OldDigree;
    
    // Use this for initialization
    void Awake()
    {
        int RandMaterial = Random.Range(0, FishMaterial.Length);
        int RandomSize = Random.Range(30, 90);
        float sumSize = RandomSize * 0.01f;
        MoveEndTrans.position = EndPos; MoveState = 1;
        MaterialTrans.GetComponent<Renderer>().material = FishMaterial[RandMaterial];
        transform.localScale = new Vector3(sumSize, sumSize, sumSize);
    }

    void Start () {
        OldDigree = 0;
    }
	
	// Update is called once per frame
	void Update () {
        switch (MoveState)
        {
            case 0:
            case 3:
                //transform.localPosition = Vector2.Lerp(transform.localPosition, MoveEndTrans.localPosition, MoveSpeed);
                digree = LookAt2D(transform.localPosition, MoveEndTrans.localPosition);
                break;
            case 1:
                Invoke("NextTargetGo", 0.006f);
                MoveState = 2;
                break;
            case 2:
                break;
        }

    }

    private void FixedUpdate()
    {
        switch (MoveState)
        {
            case 0:
            case 3:
                //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, digree));
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, digree)), MoveSpeed * Time.deltaTime);
                transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
                break;
        }
    }

    int RandomType;
    void NextTargetGo()
    {
        EndPos = Random.insideUnitCircle.normalized * 7;
        //원형으로 했더니 나가 있는 경우가 너무 많을 때가 있다
        int subRandomType = Random.Range(0, 4);
        if (subRandomType != RandomType)
            RandomType = subRandomType;
        else
            RandomType = Random.Range(0, 4);

        switch (RandomType)
        {
            case 0:
                EndPos.x = Random.Range(-GaroHalfSize, GaroHalfSize);
                EndPos.y = -SeroHalfSize;
                break;
            case 1:
                EndPos.x = Random.Range(-GaroHalfSize, GaroHalfSize);
                EndPos.y = SeroHalfSize;
                break;
            case 2:
                EndPos.x = -GaroHalfSize;
                EndPos.y = Random.Range(-SeroHalfSize, SeroHalfSize);
                break;
            case 3:
                EndPos.x = GaroHalfSize;
                EndPos.y = Random.Range(-SeroHalfSize, SeroHalfSize);
                break;
        }

        MoveEndTrans.localPosition = EndPos;
        MoveEndTrans.gameObject.SetActive(true);

        MoveState = 0;
    }

    public float LookAt2D(Vector2 Taget, Vector2 LootObj)
    {
        float retFloat = 0;

        retFloat = Mathf.Atan2(Taget.y - LootObj.y,
                           Taget.x - LootObj.x) * 180 / Mathf.PI;

        retFloat -= 90;
        return retFloat;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == MoveEndTrans.GetComponent<Collider2D>())
        {
            other.gameObject.SetActive(false);
            MoveState = 1;
        }
        if(other.tag.Equals("HandObj2D"))
        {
            MoveEndTrans.gameObject.SetActive(false);
            MoveState = 1;
        }
    }
}
