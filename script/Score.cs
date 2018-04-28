using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    private float score = 0.0f;
    public Text scoreText;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 5;
    private int scoreToNextLevel = 5;
    private bool isdead = false;

    public DeathMenu deathmenu;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isdead)
        { return; }

        if (score >= scoreToNextLevel)
        { levelUp(); }
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
	}

    void levelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        { return; }

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<code>().SetSpeed(difficultyLevel);
        score += Time.deltaTime * difficultyLevel;
    }

    public void onDeath()
    {
        isdead = true;
        deathmenu.toggleEndMenu(score);
    }
}
