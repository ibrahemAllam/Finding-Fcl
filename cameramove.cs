using System.Collections;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    // Use this for initialization
    void Start()    
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;

    }

    // Update is called once per frame
    void Update()
    {
     
            //normal camera movement
            transform.position = lookAt.position + startOffset;
    }
}
