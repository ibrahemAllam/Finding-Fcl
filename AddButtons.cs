using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour {
    [SerializeField]
    private Transform PuzzleField;

    [SerializeField]
    private GameObject btn;

      void Awake()
    {
        for(int i = 0; i < 8 ; i ++) //place 8 Buttons
        {
            GameObject button = Instantiate(btn);   // creating gameobject we provide
            button.name = "" + i;                   //naming our Buttons
            button.transform.SetParent(PuzzleField , false ); //cuz we don't want our world position to stay
        }
        
    }
}
