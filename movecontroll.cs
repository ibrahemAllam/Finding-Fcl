using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class movecontroll : MonoBehaviour
{

    private CharacterController controller;
    public Transform playerTransform;
    private Animator anim;
    private Vector3 moveVector;
    public bool isGrounded;
    private float speed = 5f;
    bool runkey = false;
    bool jump = false;
    bool dead = false;
    bool puzzle = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        isGrounded = true; //indicate that we are in the ground

        controller = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }
    public void increass_speed(int more)
    {
        speed = 5f + more / 2;
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "Running forward":
                anim.SetBool("isrunningforward", true);

                anim.SetBool("isidle", false);
                anim.SetBool("isjumping", false);
                break;

            case "idle":
                anim.SetBool("isrunningforward", false);

                anim.SetBool("isidle", true);
                anim.SetBool("isjumping", false);
                break;
            case "jumping":
                anim.SetBool("isrunningforward", false);

                anim.SetBool("isidle", false);
                //anim.SetBool("isjumping", true);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;

        if (jump)
        {
            movementControl("jumping");

            moveVector.y = -2.25f * speed;

            controller.Move(moveVector * Time.deltaTime);

            jump = false;
        }

        if (isGrounded)
        {
            //moving forward 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            { runkey = true; }

            if (runkey)
            {
                movementControl("Running forward");
                moveVector = Vector3.zero;
                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
                moveVector.z = speed;
                controller.Move(moveVector * Time.deltaTime);
                if (playerTransform.position.x < -1.4f || playerTransform.position.x > 1.4f)
                {
                    if (playerTransform.position.y < .9f)
                        deth();
                }
            }


            if (Input.GetKey(KeyCode.Space))
            {

                movementControl("jumping");
                moveVector.y = 16f;
                controller.Move(moveVector * Time.deltaTime);
                jump = true;

            }

        }

    }

    private void OnControllerColliderHit(ControllerColliderHit Hit)
    {

        if (playerTransform.position.z > 200f)
            SceneManager.LoadScene("puzzle hard");
        else
            if (Hit.point.z > playerTransform.position.z + controller.radius)
                deth();
    }
    void deth()
    {
        dead = true;
        movementControl("idle");
        GetComponent<myscore1>().deathmenu();

    }
}