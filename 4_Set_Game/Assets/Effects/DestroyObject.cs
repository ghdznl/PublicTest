using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    public float DeletTime = 2;
	// Use this for initialization
	void Start () {
        Invoke("DeletCall", DeletTime);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DeletCall()
    {
        Destroy(gameObject);
    }
}
