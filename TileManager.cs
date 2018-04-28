
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform PlayerTransform;
    private float spawnZ = -25.0f;
    private float tileLength = 7.5f;
    private int amTileOnScreen = 8;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles ;

	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0;  i< amTileOnScreen; i++)
        {
            if (i < 2)
            { SpawnTile(0); }
            else
            { SpawnTile(); }    
         
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerTransform.position.z -safeZone > (spawnZ - amTileOnScreen*tileLength  ) )
        {
            SpawnTile();
            DeleteTile();

        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[randomGenerate()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex])  as GameObject ;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int randomGenerate()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomindex = lastPrefabIndex;

        while( randomindex == lastPrefabIndex)
        {
            randomindex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomindex;
        return randomindex;
            
    }

     
}
