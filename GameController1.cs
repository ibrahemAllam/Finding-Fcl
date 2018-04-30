using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//we need areference to every button using a Dynamic List
public class GameController1 : MonoBehaviour {
    [SerializeField]
    private Sprite BGimg;

    public Sprite[] Puzzles;

    public List<Sprite> GamePuzzles = new List<Sprite>();

    private bool FirstGuess, SecondGuess;

    private int CountGuesses;
    private int CountCorrectGuesses;
    private int GameGuesses;

    private int firstGuessindex, secondGuessindex;

    private string firstguesspuzzle, secoundguesspuzzle;

    public void Awake()
    {
        Puzzles = Resources.LoadAll<Sprite>("sprites/RPG_inventory_icons");
    }

    public List<Button> btns = new List<Button>();
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzels();
        suffle(GamePuzzles);
        GameGuesses = GamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i=0 ; i < objects.Length ; i++  )
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = BGimg;

        }
    }
    
    void AddGamePuzzels()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i=0; i<looper; i++)
        {
            if(index == looper/2)
            {
                index = 0;
            }
            GamePuzzles.Add(Puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickApuzzle());

        }
    }

    public void PickApuzzle()
    {
        // To get & Determine the name of the selected btn

        //Debug.Log("you are Clicking a button named " + name);
        if (!FirstGuess)
        {
            FirstGuess = true;

            firstGuessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstguesspuzzle = GamePuzzles[firstGuessindex].name;

            btns[firstGuessindex].image.sprite = GamePuzzles[firstGuessindex];
        }
        else if (!SecondGuess)
        {
            SecondGuess = true;

            secondGuessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secoundguesspuzzle = GamePuzzles[secondGuessindex].name;

            btns[secondGuessindex].image.sprite = GamePuzzles[secondGuessindex];



            StartCoroutine(Checkifthepuzzlesmatch());
        }
      }

        IEnumerator Checkifthepuzzlesmatch()
        {
            yield return new WaitForSeconds(1f);
            if( firstguesspuzzle == secoundguesspuzzle)
            {
            yield return new WaitForSeconds(.5f);

            btns[firstGuessindex].interactable = false;
            btns[secondGuessindex].interactable = false;

            btns[firstGuessindex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessindex].image.color = new Color(0, 0, 0, 0);

            checkifthegamefinish();
            }
            else
            {
            btns[firstGuessindex].image.sprite = BGimg;
            btns[secondGuessindex].image.sprite = BGimg;
            }
            yield return new WaitForSeconds(.5f);

            FirstGuess = SecondGuess = false;
    }
    void checkifthegamefinish()
    {
        CountCorrectGuesses++;
        if(CountCorrectGuesses == GameGuesses )
        {
            SceneManager.LoadScene("1");
            StreamWriter lv = new StreamWriter(Application.dataPath + "/Resources/lv2.txt");
            lv.WriteLine("1");
            lv.Close();
        }
    }

    void suffle(List<Sprite>list)
    {
        for (int i=0 ; i<list.Count ; i++ )
        {
            Sprite temp = list[i];
            int randomindex = Random.Range(0, list.Count);
            list[i] = list[randomindex];
            list[randomindex] = temp;
        }
    }
    }


