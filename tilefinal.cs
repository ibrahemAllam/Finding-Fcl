using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class tilefinal : MonoBehaviour {
    public GameObject[] tilePreflasbs;

    private Transform playerTransform;
    private float spawnZ = -10.0f;
    private float tileLenght = 338.0f;
    private float safeZone = 400.0f;
    private int amnTileOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    // Use this for initialization
    void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("player").transform;
        for (int i = 0; i < amnTileOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLenght))
        {
            SpawnTile();
            DeleteTile();
        }

    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePreflasbs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePreflasbs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLenght;
        activeTiles.Add(go);
    }
    private void DeleteTile()

    {
        Destory(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void Destory(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    private int RandomPrefabIndex()
    {
        if (tilePreflasbs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, tilePreflasbs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
