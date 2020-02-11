using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;
    private Vector3 startPosition;
    public static bool isDead = false;
    Rigidbody rb;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Fire")
        {
            anim.SetTrigger("isDead");
            isDead = true;
        }
        else
        {
            currentPlatform = other.gameObject;
        }
        currentPlatform = other.gameObject;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        player = this.gameObject;
        startPosition = player.transform.position;

        GenerateEnviroment.RunDummy();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other is BoxCollider && GenerateEnviroment.lastPlatform.tag != "platformTSection")  /////
        {
            GenerateEnviroment.RunDummy();
        }

        if (other is SphereCollider)
        {
            canTurn = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
        {
            canTurn = false;
        }
    }

    void StopJump()
    {
        anim.SetBool("isJumping", false);
    }

    void StopMagic()
    {
        anim.SetBool("isMagic", false);
    }


    void Update()
    {
        if (PlayerController.isDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isMagic") == false)
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 200);
        }
        else if (Input.GetKeyDown(KeyCode.M) && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateEnviroment.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateEnviroment.RunDummy();

            if (GenerateEnviroment.lastPlatform.tag != "platformTSection")
            {
                GenerateEnviroment.RunDummy();
            }
            
            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateEnviroment.dummyTraveller.transform.forward = -this.transform.forward;
            GenerateEnviroment.RunDummy();

            if (GenerateEnviroment.lastPlatform.tag != "platformTSection")
            {
                GenerateEnviroment.RunDummy();
            }

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
    }
}
