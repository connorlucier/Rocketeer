using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float rcsThrust;

    [SerializeField]
    float mainThrust;

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

        if (rcsThrust <= 0)
        {
            rcsThrust = 150.0f;
        }

        if (mainThrust <= 0)
        {
            mainThrust = 250.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        ThrustShip();
        RotateShip();
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Friendly")
        {
            print("Dead");
        }
    }

    private void ThrustShip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        }
    }

    private void RotateShip()
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rcsThrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rcsThrust * Time.deltaTime);
        }

        rigidBody.freezeRotation = false;
    }
}
