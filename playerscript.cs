using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour {

    private CharacterController controller;

    private Vector3 moveVector;

    private float speed = 5.0f;

    private float verticalvelocity = 0.0f;

    private float gravity = 12.0f;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        

	}
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;

        if ( controller.isGrounded  )
        {
            verticalvelocity = -0.5f;
        }
        else
        {
            verticalvelocity -= gravity * Time.deltaTime;
        }

        //x left nd right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //y  up nd down
        moveVector.y = verticalvelocity;

        //z  forward nd backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

    }
}
