using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageControll : MonoBehaviour {
    public GameObject target;
    public bool startmove=false;
    GameController gameNN;
	// Use this for initialization
	void Start () {
        GameObject gamemanger = GameObject.Find("GameController");
        gameNN = gamemanger.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(startmove)
        {
            startmove = false;
            this.transform.position = target.transform.position;
            gameNN.checkcomplete = true;
        }
		
	}
}
