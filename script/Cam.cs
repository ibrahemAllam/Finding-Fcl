using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    
    [SerializeField]
    Transform target;
    Vector3 Offset;
    


    // Use this for initialization
    void Start()
    {
        Offset = target.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.transform.position - Offset;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, 1.5f);
    }
}
