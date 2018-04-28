using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager1 : MonoBehaviour {


    public GameObject[] tilePreflasbs;
    private List<GameObject> activeTiles;
    private Transform playerTransform;
    private float spawnZ = 13f;
    private float tileLenght = 7.0f;
    private float safeZone = 20.0f;
    private int amnTileOnScreen = 10;
    private int lastPrefabIndex = 0;

    // Use this for initialization
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTileOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTileOnScreen * tileLenght))
        {
            if (playerTransform.position.z > 145f)
            {
                SpawnTile(0);
                DeleteTile();
            }
            else
            {
                SpawnTile();
                DeleteTile();
            }
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
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
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
