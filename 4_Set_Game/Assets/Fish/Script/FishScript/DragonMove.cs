using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour {

    //public GameObject BodyPrefab;
    public GameObject Body2Prefab;
    public GameObject TailPrefab;

    public Material[] DragonHead_Material;
    public Transform DragonHead_MaterialTrans;
    public Transform mDragonHeadShadow;


    public int Type = 0;
    public int DragonLv;
    public float MOVlerpTime = 0.15f;

    public Transform HeadPos; // 따라갈 타겟의 트랜스 폼

    public List<Transform> Body;
    int RandMaterial;

    Color ShadowColor = new Color(0, 0, 0, 0.3f);

    float StartZPos;
    int BodyCreatCount = 0;
    // Use this for initialization
    void Awake()
    {
        StartZPos = 0;
        Body2Prefab = transform.Find("Body_2").gameObject;
        TailPrefab = transform.Find("Tail").gameObject;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init()
    {
        Body.Clear();

        BodyCreatCount = 0;

        //= Random.Range(0, FishMaterial.Length);
        RandMaterial = Random.Range(0, DragonHead_Material.Length);

        DragonHead_MaterialTrans.GetComponent<Renderer>().material = DragonHead_Material[RandMaterial];

        Material mShadowMaterial = new Material(DragonHead_MaterialTrans.GetComponent<Renderer>().material);
        mShadowMaterial.SetColor("_TintColor", ShadowColor);
        mDragonHeadShadow.GetComponent<Renderer>().material = mShadowMaterial;

        Invoke("CreateDragonBody", 0.05f);
    }

    void CreateDragonBody()
    {
        GameObject tempBody;
        if (Type == 0)
        {
            if (BodyCreatCount < DragonLv)
            {
                tempBody = Instantiate(Body2Prefab, HeadPos.position, Quaternion.identity, transform); ;
                tempBody.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                Invoke("CreateDragonBody", 0.05f);
            }
            else
            {
                //꼬리 생성
                tempBody = Instantiate(TailPrefab, HeadPos.position, Quaternion.identity, transform);
                tempBody.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }
        else
        {
            if (BodyCreatCount < DragonLv)
            {
                tempBody = Instantiate(Body2Prefab, HeadPos.position, Quaternion.identity, transform);
                tempBody.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                Invoke("CreateDragonBody", 0.05f);
            }
            else
            {
                //꼬리 생성
                tempBody = Instantiate(TailPrefab, HeadPos.position, Quaternion.identity, transform);
                tempBody.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }

        tempBody.SetActive(true);
        Body.Add(tempBody.transform);
        BodySetting();

        Transform mShadow = tempBody.transform.GetChild(0);
        Material mShadowMaterial = new Material(tempBody.GetComponent<Renderer>().material);
        mShadowMaterial.SetColor("_TintColor", ShadowColor);
        mShadow.GetComponent<Renderer>().material = mShadowMaterial;

        BodyCreatCount++;
    }

    void BodySetting()
    {
        DragonBodyLogic DBL = Body[BodyCreatCount].GetComponent<DragonBodyLogic>();
        DBL.MOVlerpTime = this.MOVlerpTime;
        DBL.MatTypeNumber = RandMaterial;
        DBL.MatInit();

        StartZPos = Body[BodyCreatCount].transform.position.z + 0.0001f;
        DBL.ZPos = StartZPos;
        if (BodyCreatCount == 0)
        {//최초의 바디는 머리가 타겟이다
            DBL.Target = HeadPos;
        }
        else
        {
            int NowCreatCount = BodyCreatCount - 1;
            DBL.Target = Body[NowCreatCount];
        }
    }

    public void AddBody()
    {
        BodyCreatCount--;
        Destroy(Body[BodyCreatCount].gameObject);
        Body.RemoveAt(BodyCreatCount);
        Invoke("CreateDragonBody", 0.05f);
    }
}
