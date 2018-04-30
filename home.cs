using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class home : MonoBehaviour {

    public void lv1()
    {
        SceneManager.LoadScene("environment");
    }
    public void lv2()
    {
        SceneManager.LoadScene("Scene_winter");
    }
    public void lv3()
    {
        SceneManager.LoadScene("1");
    }
    public void exitgame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
