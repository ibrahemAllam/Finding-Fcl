using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoretext;
    public Image backgroundImg;

    private bool isshowed = false;
    private float transition = 0.0f;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isshowed)
        { return; }
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}
    public void toggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoretext.text = ((int)score).ToString();
        isshowed = true;
    }
    public void Rsstart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
