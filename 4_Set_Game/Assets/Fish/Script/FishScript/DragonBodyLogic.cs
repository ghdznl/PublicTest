using UnityEngine;
using System.Collections;

public class DragonBodyLogic : MonoBehaviour
{
    Transform ThisTrans;
    public Transform Target;
    public int MatTypeNumber = 0;
    public float MOVlerpTime = 0.5f;
    public float rotatingSpeed = 0.7f;
    public int speedMultiplier = 2;
    public float ZPos;

    public Material[] mGetMaterial;
    // Use this for initialization
    void Start()
    {
        ThisTrans = this.transform;
    }

    public void MatInit()
    {
        GetComponent<Renderer>().material = mGetMaterial[MatTypeNumber];
    }

    Vector3 NowPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target != null)
        {
            //float direction = LookAt2D(transform.position, Target.position);
            //Vector2 referencePosition = Target.transform.position - Target.transform.forward;

            //transform.localRotation = Quaternion.Euler(new Vector3(0, 0, direction));
            //NowPos = Vector2.Lerp(transform.position, referencePosition, MOVlerpTime);
            //NowPos.z = ZPos;
            //transform.position = NowPos;

            float direction = LookAt2D(ThisTrans.position, Target.position);
            Vector2 referencePosition = Target.transform.position - Target.transform.forward;

            ThisTrans.localRotation = Quaternion.Euler(new Vector3(0, 0, direction));
            NowPos = Vector2.Lerp(ThisTrans.position, referencePosition, MOVlerpTime);
            NowPos.z = ZPos;
            ThisTrans.position = NowPos;
        }
    }

    public float LookAt2D(Vector2 Taget, Vector2 LootObj)
    {
        float retFloat = 0;

        retFloat = Mathf.Atan2(Taget.y - LootObj.y,
                           Taget.x - LootObj.x) * 180 / Mathf.PI;

        retFloat -= 90;
        return retFloat;
    }
}
