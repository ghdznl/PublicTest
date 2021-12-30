using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomAni2D : MonoBehaviour
{
    private void Awake()
    {
        TomImage.sprite = Resources.Load<Sprite>("Tom/Tom_1");
        AnImage.sprite = Resources.Load<Sprite>("An/An_1");
    }

    // Use this for initialization
    private void Start()
    {
        TomCall();
        AnCall();
    }

	// Update is called once per frame
    private void Update()
    {
        if (!TomAniCheck)
        {
            TomCall();
        }
        if (!AnAniCheck && !AnAniEndCheck)
        {
            AnCall();
        }
    }

    public Image TomImage;
    bool TomAniCheck = false;
    int TomAniIndex = 1;
    void TomCall()
    {
        TomAniCheck = true;
        TomAniIndex = 1;
        StartCoroutine("TomAniCall");
    }

    IEnumerator TomAniCall()
    {
        while (TomAniCheck)
        {
            yield return new WaitForSeconds(.03f);

            TomImage.sprite = Resources.Load<Sprite>("Tom/Tom_" + TomAniIndex);

            TomAniIndex++;
            if (TomAniIndex > 180)
            {
                TomAniCheck = false;
                TomImage.sprite = Resources.Load<Sprite>("Tom/Tom_1");
            }
        }
    }


    public Image AnImage;
    bool AnAniCheck = false;
    bool AnAniEndCheck = false;
    int AnAniIndex = 1;
    void AnCall()
    {
        AnAniCheck = true;
        AnAniIndex = 1;
        StartCoroutine("AnAniCall");
    }

    IEnumerator AnAniCall()
    {
        while (AnAniCheck)
        {
            yield return new WaitForSeconds(.03f);

            AnImage.sprite = Resources.Load<Sprite>("An/An_" + AnAniIndex);

            AnAniIndex++;
            if (AnAniIndex > 180)
            {
                AnAniCheck = false;
                AnAniIndex = 30;
                AnAniEndCheck = true;
                StartCoroutine("AnAni_End");
                //AnImage.sprite = Resources.Load<Sprite>("An/An_1");
            }
        }
    }

    IEnumerator AnAni_End()
    {
        while (AnAniEndCheck)
        {
            yield return new WaitForSeconds(.03f);

            AnImage.sprite = Resources.Load<Sprite>("An/An_" + AnAniIndex);

            AnAniIndex--;
            if (AnAniIndex < 1)
            {
                AnAniEndCheck = false;
                AnImage.sprite = Resources.Load<Sprite>("An/An_1");
            }
        }
    }
}
