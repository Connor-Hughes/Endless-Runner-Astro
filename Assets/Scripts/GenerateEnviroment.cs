using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEnviroment : MonoBehaviour
{
    static public GameObject dummyTraveller;
    static public GameObject lastPlatform;

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    void Awake()
    {
        dummyTraveller = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        if (p == null) return;

        if (lastPlatform != null) //setting the dummy to be one tile ahead
        {
            if (lastPlatform.tag == "platformTSection")
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20; ////
            }
            else
            {
                dummyTraveller.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10; ////
            }

            if (lastPlatform.tag == "stairsUp")
            {
                dummyTraveller.transform.Translate(0, 5, 0);
            }
        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyTraveller.transform.position;
        p.transform.rotation = dummyTraveller.transform.rotation;

        if (p.tag == "stairsDown")
        {
            dummyTraveller.transform.Translate(0, -5, 0);
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummyTraveller.transform.position;
        }
    }
}
    //    for (int i = 0; i < 30; i++)
    //    {
    //        GameObject p = Pool.singleton.GetRandom();
    //        if (p == null)
    //            return;

    //        p.SetActive(true);
    //        p.transform.position = dummyTraveller.transform.position;
    //        p.transform.rotation = dummyTraveller.transform.rotation;

    //        if (p.tag == "stairsUp")
    //        {
    //            dummyTraveller.transform.Translate(0, 5, 0);
    //        }
    //        else if (p.tag == "stairsDown")
    //        {
    //            dummyTraveller.transform.Translate(0, -5, 0);
    //            p.transform.Rotate(new Vector3(0, 180, 0));
    //            p.transform.position = dummyTraveller.transform.position;
    //        }
    //        else if (p.tag == "platformTSection")
    //        {
    //            if (Random.Range(0, 2) == 0)
    //            {
    //                dummyTraveller.transform.transform.Rotate(new Vector3(0, 90, 0));
    //            }
    //            else
    //            {
    //                dummyTraveller.transform.transform.Rotate(new Vector3(0, -90, 0));

    //                dummyTraveller.transform.Translate(Vector3.forward * -10);
    //            }
    //        }
    //        dummyTraveller.transform.Translate(Vector3.forward * -10);
    //    }

