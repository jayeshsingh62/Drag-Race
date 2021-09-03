using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Private variables
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private float horsePower = 0;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;

    // Public variables
    public Camera cam1;
    public Camera cam2;
    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal1");
        forwardInput = Input.GetAxis("Vertical1");

        // Move the vehicle forward based on vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        // Rotate the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Change the camera
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }

    private void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); //change 2.237 to 3.6 for kph
    }
}
