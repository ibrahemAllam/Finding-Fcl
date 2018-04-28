using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code : MonoBehaviour {

    private CharacterController controller;
    private Rigidbody rb;
    [SerializeField]
    private float speed = 5.0f;
    private Animator anim;
    private float tilelength = 12.5f;
    private int lastprefabindex;
    private bool isdead = false;

    float lenghtinzaxis = 7.6f;
    Vector3 lastposition;

    [SerializeField]
    GameObject platform;

    [SerializeField]
    Transform firstObject;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rb.velocity = new Vector3(0f, 0f, z: speed);
        lastposition = firstObject.transform.position;
        InvokeRepeating("Spawning",0f ,0.3f);
	}

    private void Spawning()
    {
        GameObject _object = Instantiate(platform) as GameObject;
        _object.transform.position = lastposition + new Vector3(0f, 0f, lenghtinzaxis);
        lastposition = _object.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (isdead)
        { return; }

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(0f, 7f, 0f, ForceMode.Impulse);
            anim.Play("jumping");
        }
	}

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Stone")
        {
            return;
        }
        //check if we hit an object that is in fornt of us
        if (hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Menu");
        isdead = true;
        GetComponent<Score>().onDeath();
    }
}
