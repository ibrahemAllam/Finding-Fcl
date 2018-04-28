using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int row, col , countstep;
    public int rowblank, colblank;
    public bool startcontroll = false;
    public int SizeRow, SizeCol;
    public int countpoint=0;
    public int countimagekey = 0;
    public bool checkcomplete;
    public List<GameObject> imagekeylist;
    public List<GameObject> imageofpicturelist;
    public List<GameObject> checkpointlist;
    public int countcomplete=0;
    public bool gameiscomplete;
    GameObject[,] imagekeymatrix;
    GameObject[,] imageofpicturematrix;
    GameObject[,] checkpoinmatrix;

    GameObject temp;
    public int level;
    // Use this for initialization
    void Start () {
        imagekeymatrix = new GameObject[SizeRow, SizeCol];
        imageofpicturematrix = new GameObject[SizeRow, SizeCol];
        checkpoinmatrix = new GameObject[SizeRow, SizeCol];
        if(level==1)
        {
            imageEasyLeve();
        }
        else if(level==2)
        {
            imagehardlevel();
        }
        checkpointmanger();
        ImagekeyManger();
        for (int r = 0; r < SizeRow; r++)
        {
            for (int c = 0; c < SizeCol; c++)
            {
                if(imageofpicturematrix[r, c].name.CompareTo("blank")==0)
                {
                    rowblank = r;
                    colblank = c;
                    break;
                }
               // countpoint++;
            }
        }

    }
    void checkpointmanger()
    {
        for (int r = 0; r < SizeRow; r++)
        {
            for (int c = 0; c < SizeCol; c++)
            {
                checkpoinmatrix[r, c] = checkpointlist[countpoint];
                countpoint++;
            }
        }
    }
    void ImagekeyManger()
    {
        for (int r = 0; r < SizeRow; r++)
        {
            for (int c = 0; c < SizeCol; c++)
            {
                imagekeymatrix[r, c] = imagekeylist[countimagekey];
                countimagekey++;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(startcontroll)
        {
            startcontroll = false;
            if (countstep == 1)
            {
                if (imageofpicturematrix[row, col] !=null && imageofpicturematrix[row, col].name.CompareTo("blank") != 0)
                {
                    if (rowblank != row && colblank == col)
                    {
                        if (Mathf.Abs(row - rowblank) == 1)
                        {


                            sortimage();
                            countstep = 0;

                        }
                        else
                        {
                            countstep = 0;
                        }
                    }
                    else if (rowblank == row && colblank != col)
                    {
                        if (Mathf.Abs(col - colblank) == 1)
                        {
                            sortimage();
                            countstep = 0;
                        }
                        else
                        {
                            countstep = 0;
                        }
                    }
                    else if ((rowblank == row && colblank == col) || (rowblank != row && colblank != col))
                    {
                        countstep = 0;
                    }

                } else
                {
                    countstep = 0;
                }
            }
        }
		
	}
    void FixedUpdate()
    {
        if(checkcomplete)
        {
            checkcomplete = false;
            for (int r = 0; r < SizeRow; r++)
            {
                for (int c = 0; c < SizeCol; c++)
                {
                  if(  imagekeymatrix[r, c].gameObject.name.CompareTo(imageofpicturematrix[r,c].gameObject.name)==0 )
                    {
                        countcomplete++;
                    }
                  else
                    { break; }
                    
                }
            }
            if(countcomplete==checkpointlist.Count)
            {
                gameiscomplete = true;
                Debug.Log("level is complete");
                Application.LoadLevel("2");
                


            }
            else { countcomplete = 0; }
        }
    }
    void sortimage()
    {
        temp = imageofpicturematrix[rowblank, colblank];
        imageofpicturematrix[rowblank, colblank] = null;
        imageofpicturematrix[rowblank, colblank] = imageofpicturematrix[row, col];
        imageofpicturematrix[row, col] = null;
        imageofpicturematrix[row, col] = temp;
        imageofpicturematrix[rowblank, colblank].GetComponent<ImageControll>().target = checkpoinmatrix[rowblank, colblank];
        imageofpicturematrix[row, col].GetComponent<ImageControll>().target = checkpoinmatrix[row, col];
        imageofpicturematrix[rowblank, colblank].GetComponent<ImageControll>().startmove = true;
        imageofpicturematrix[row, col].GetComponent<ImageControll>().startmove = true;
        rowblank = row;
        colblank = col;
    }
    void imageEasyLeve()
    {
        imageofpicturematrix[0, 0] = imageofpicturelist[0];
        imageofpicturematrix[0, 1] = imageofpicturelist[2];
        imageofpicturematrix[0, 2] = imageofpicturelist[5];
        imageofpicturematrix[1, 0] = imageofpicturelist[4];
        imageofpicturematrix[1, 1] = imageofpicturelist[1];
        imageofpicturematrix[1, 2] = imageofpicturelist[7];
        imageofpicturematrix[2, 0] = imageofpicturelist[3];
        imageofpicturematrix[2, 1] = imageofpicturelist[6];
        imageofpicturematrix[2, 2] = imageofpicturelist[8];

    }
    void imagehardlevel()
    {
        imageofpicturematrix[0, 0] = imageofpicturelist[5];
        imageofpicturematrix[0, 1] = imageofpicturelist[2];
        imageofpicturematrix[0, 2] = imageofpicturelist[3];
        imageofpicturematrix[0, 3] = imageofpicturelist[4];
        imageofpicturematrix[0, 4] = imageofpicturelist[9];
        imageofpicturematrix[1, 0] = imageofpicturelist[10];
        imageofpicturematrix[1, 1] = imageofpicturelist[1];
        imageofpicturematrix[1, 2] = imageofpicturelist[12];
        imageofpicturematrix[1, 3] = imageofpicturelist[7];
        imageofpicturematrix[1, 4] = imageofpicturelist[8];
        imageofpicturematrix[2, 0] = imageofpicturelist[15];
        imageofpicturematrix[2, 1] = imageofpicturelist[6];
        imageofpicturematrix[2, 2] = imageofpicturelist[13];
        imageofpicturematrix[2, 3] = imageofpicturelist[14];
        imageofpicturematrix[2, 4] = imageofpicturelist[19];
        imageofpicturematrix[3, 0] = imageofpicturelist[20];
        imageofpicturematrix[3, 1] = imageofpicturelist[11];
        imageofpicturematrix[3, 2] = imageofpicturelist[22];
        imageofpicturematrix[3, 3] = imageofpicturelist[17];
        imageofpicturematrix[3, 4] = imageofpicturelist[18];
        imageofpicturematrix[4, 0] = imageofpicturelist[21];
        imageofpicturematrix[4, 1] = imageofpicturelist[16];
        imageofpicturematrix[4, 2] = imageofpicturelist[23];
        imageofpicturematrix[4, 3] = imageofpicturelist[24];
        imageofpicturematrix[4, 4] = imageofpicturelist[0];
    }
}
