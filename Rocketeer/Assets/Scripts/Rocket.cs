using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ThrustShip();
        RotateShip();
	}

    private void ThrustShip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * 20);
        }
    }

    private void RotateShip()
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward / (Time.deltaTime * 40));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back / (Time.deltaTime * 40));
        }

        rigidBody.freezeRotation = false;
    }
}
