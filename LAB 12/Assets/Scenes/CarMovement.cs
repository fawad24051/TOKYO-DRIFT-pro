/*
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 50f; // Rotation speed

    void Update()
    {
        // Move the car forward/backward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            Debug.Log("W key is held down");
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            Debug.Log("S key is held down");
        }

        // Rotate the car around its local Y-axis
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0); // Rotate left around Y-axis
            Debug.Log("A key is held down");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0); // Rotate right around Y-axis
            Debug.Log("D key is held down");
        }
    }
}
*/


/*
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Movement speed
    public float steeringAngle = 30f; // Maximum steering angle
    public float maxSpeed = 20f;      // Maximum speed limit
    private float currentSteerAngle;  // Current steering angle
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero; // Adjust the center of mass to improve stability
    }

    void Update()
    {
        // Get input for forward/backward movement and steering
        float moveInput = Input.GetAxis("Vertical");    // W/S or Up/Down Arrow
        float steerInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow

        // Move the car forward/backward
        MoveCar(moveInput);

        // Rotate/steer the car
        SteerCar(steerInput);

        // Limit the car's speed
        LimitSpeed();
    }

    private void MoveCar(float moveInput)
    {
        // Translate the car forward/backward
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
    }

    private void SteerCar(float steerInput)
    {
        // Calculate the steering angle based on input
        currentSteerAngle = steeringAngle * steerInput;

        // Rotate the car around its local Y-axis for steering
        transform.Rotate(0f, currentSteerAngle * Time.deltaTime, 0f);
    }

    private void LimitSpeed()
    {
        // Limit the velocity to prevent exceeding maxSpeed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
*/

using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Movement speed
    public float steeringAngle = 30f; // Maximum steering angle
    public float rotationSpeed = 2f;  // Smooth rotation speed for turning
    public float maxSpeed = 20f;      // Maximum speed limit
    private float currentSteerAngle;  // Current steering angle
    private Rigidbody rb;             // Rigidbody for physics-based movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero; // Adjust center of mass for stability
    }

    void Update()
    {
        // Get input for movement and steering
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = 1f; // Forward
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput = -1f; // Backward
        }

        float steerInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            steerInput = -1f; // Turn left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            steerInput = 1f; // Turn right
        }

        // Move and steer the car
        MoveCar(moveInput);
        SteerCar(steerInput);

        // Limit the car's speed
        LimitSpeed();
    }

    private void MoveCar(float moveInput)
    {
        // Move forward/backward relative to the car's forward direction
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
    }

    private void SteerCar(float steerInput)
    {
        // Calculate the desired steering angle
        currentSteerAngle = steerInput * steeringAngle;

        // Smoothly rotate the car towards the target steering angle
        Quaternion targetRotation = Quaternion.Euler(0f, currentSteerAngle, 0f) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void LimitSpeed()
    {
        // Limit velocity to the maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}


/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
*/