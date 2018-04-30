using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locked : MonoBehaviour {

    private string lv;
	// Use this for initialization
	void Start () {
        TextAsset test = (TextAsset)Resources.Load("lv2");
        lv = test.text;

        if (lv != "0")
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        TextAsset test = (TextAsset)Resources.Load("lv2");
        lv = test.text;
            if (lv != "0") 
            gameObject.SetActive(false);
           
	}
}
