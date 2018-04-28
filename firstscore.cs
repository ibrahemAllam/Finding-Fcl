﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstscore : MonoBehaviour
{

    private float score = 0.0f;
    public Text scoretext;
    private int difficulte = 1;
    private int scorenextlv = 100;
    public deathmenu dmenu;
    bool isdead = false;
    // Use this for initialization
    // Update is called once per frame
    void Update()
    {

        if (isdead)
            return;

        if (score >= scorenextlv)
            levelup();
        if (GetComponent<playercontroll>().playerTransform.position.z >= 1)
        {
            score += Time.deltaTime;
            scoretext.text = ((int)score).ToString();
        }
    }
    void levelup()
    {

        scorenextlv *= 2;
        difficulte++;
        GetComponent<playercontroll>().increass_speed(difficulte);

    }
    public void deathmenu()
    {
        isdead = true;
        dmenu.menu(score);

    }
}
