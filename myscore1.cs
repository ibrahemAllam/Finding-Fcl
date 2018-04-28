using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myscore1 : MonoBehaviour
{


    private float score1=0f; 
    public Text scoretext;
    private int difficulte = 1;
    private int scorenextlv = 100;
    public deathmenu dmenu;
    bool isdead = false;
    // Use this for initialization
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
       
       
        if (isdead)
            return;

        if (score1 >= scorenextlv)
            levelup();
        if (GetComponent<movecontroll>().playerTransform.position.z >= .1)
        {
            score1 += Time.deltaTime;
            scoretext.text = ((int)score1).ToString();
        }
    }
    void levelup()
    {

        scorenextlv *= 2;
        difficulte++;
        GetComponent<movecontroll>().increass_speed(difficulte);

    }
    public void deathmenu()
    {
        isdead = true;
        dmenu.menu(score1);
    }
}
