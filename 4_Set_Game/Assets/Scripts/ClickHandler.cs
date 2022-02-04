using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    //is mouse button up in the last frame?fdhfdh
    bool mouseUp = true;

    public GameObject Effect;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPos;
            Ray ray;
            
            Touch[] touches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = touches[i];
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 touchPosToVector3 = new Vector3(touch.position.x, touch.position.y, 100);
                    touchPos = Camera.main.ScreenToWorldPoint(touchPosToVector3);
                    ray = Camera.main.ScreenPointToRay(touchPosToVector3);
                    int layerMask = 1 << 8;
                    if (Physics.Raycast(ray, out RaycastHit info, 1000, layerMask))
                    {
                        print("hitted " + info.collider.gameObject.name);
                        //Destroy(info.collider.gameObject);

                        Instantiate(Effect, info.collider.gameObject.transform.position, Quaternion.identity);
                        info.collider.gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100)).normalized * 10;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseUp)
                HandleClick();
            mouseUp = false;
        }
        else
            mouseUp = true;
    }
    private void HandleClick()
    {
        print("clicked");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << 8;
            if (Physics.Raycast(ray, out RaycastHit info, 1000, layerMask))
            {
                print("hitted " + info.collider.gameObject.name);
                //Destroy(info.collider.gameObject);

                Instantiate(Effect, info.collider.gameObject.transform.position, Quaternion.identity);
                info.collider.gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100)).normalized * 10;
            }
    }

}
