using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private ControllerScript _control;

    // Start is called before the first frame update
    void Start()
    {
        _control = GameObject.FindObjectOfType<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
