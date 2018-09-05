using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().transform.Translate(0, 0.2f, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().transform.Rotate(0, 0, 1.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().transform.Rotate(0, 0, -1.5f);
        }
    }
}
