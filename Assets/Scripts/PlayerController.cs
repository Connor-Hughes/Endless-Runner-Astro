using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    bool canTurn = false;

    void OnCollisionEnter(Collision other)
    {
        currentPlatform = other.gameObject;
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = this.gameObject;

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
        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isMagic") == false)
        {
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateEnviroment.dummyTraveller.transform.forward = -this.transform.forward; ////
            GenerateEnviroment.RunDummy();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateEnviroment.dummyTraveller.transform.forward = -this.transform.forward; ////
            GenerateEnviroment.RunDummy();
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
