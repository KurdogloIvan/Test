using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public GameObject Model;

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
        {
            Destroy(Model);
        }
    }
}
