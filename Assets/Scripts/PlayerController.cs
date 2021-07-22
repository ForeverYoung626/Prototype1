using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public string inputID;

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    [SerializeField] private float horsePower =20000;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsOnGround())
        {
            // Axis setup
            horizontalInput = Input.GetAxis("Horizontal" + inputID);
            forwardInput = Input.GetAxis("Vertical" + inputID);
            // Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            // Rotate the vehicle left and right
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            UpdateSpeedometer();
            UpdateRpmText();

            if (Input.GetKeyDown(switchKey))
            {
                mainCamera.enabled = !mainCamera.enabled;
                hoodCamera.enabled = !hoodCamera.enabled;
            }

        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdateSpeedometer()
    {
        speed = playerRb.velocity.magnitude * 3.6f;// 2.237 for mph
        speedometerText.SetText("Speed: " + Mathf.RoundToInt(speed) + "km/h");
    }

    void UpdateRpmText()
    {
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
}
