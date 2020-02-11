using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool dScheduled = false; // de activation schedule

    void OnCollisionExit(Collision player)
    {
        if (player.gameObject.tag == "Player" && !dScheduled)
        {
            Invoke("SetInactive", 4.0f);
            dScheduled = true;
        }
    }

    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
