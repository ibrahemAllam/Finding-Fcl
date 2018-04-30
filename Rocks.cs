using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject[] Stone_Object;

    private Transform playerTransform;
    private float spawnZ = -2.6f;
    private float tileLenght = 7.5f;
    private float safeZone = 3.0f;
    private int amnTileOnScreen = 10;
    private int lastPrefabIndex;

    private List<GameObject> activeTiles;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        for (int i = 0; i < amnTileOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.localPosition.z < spawnZ - amnTileOnScreen * tileLenght)
        {
            SpawnTile();
        }

    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(Stone_Object[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(Stone_Object[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * (spawnZ + tileLenght);
        spawnZ = spawnZ + tileLenght;
        activeTiles.Add(go);
    }

    private int RandomPrefabIndex()
    {
        if (Stone_Object.Length <= 0)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, Stone_Object.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}