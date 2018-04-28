using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStepController : MonoBehaviour {
    public int row, col;
    GameController gameNN;
    // Use this for initialization
    void Start () {
        GameObject gamemanger = GameObject.Find("GameController");
        gameNN = gamemanger.GetComponent<GameController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        Debug.Log("Row is :" + row + "Col is :" + col);
        gameNN.countstep += 1;
        gameNN.row = row;
        gameNN.col = col;
        gameNN.startcontroll = true;
    }
}
