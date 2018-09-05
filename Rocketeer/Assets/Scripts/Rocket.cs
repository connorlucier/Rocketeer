using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField]
    float transitionTime;

    [SerializeField]
    float rcsThrust;

    [SerializeField]
    float mainThrust;

    Rigidbody rigidBody;

    bool alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        alive = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            ThrustShip();
            RotateShip();
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (!alive) return;

        switch (col.gameObject.tag)
        {
            case "Finish":
                Invoke("LoadNextLevel", transitionTime);
                break;
            case "Friendly":
                break;
            default:
                alive = false;
                Invoke("LoadFirstLevel", transitionTime);
                break;
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
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
