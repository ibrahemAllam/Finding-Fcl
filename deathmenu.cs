using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class deathmenu : MonoBehaviour {

    public Text scoretext;
    private float transition;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    public void menu( float score)
    { 
        gameObject.SetActive(true);
        scoretext.text = ((int)score).ToString();
    }
		
	public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void home()
    {
        SceneManager.LoadScene("menu");
    }
}
