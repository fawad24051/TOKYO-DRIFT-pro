using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration = 1500f;
    public float steeringAngle = 30f;
    public float brakeForce = 3000f;
    public float maxSpeed = 20f;

    private Rigidbody rb;
    private float currentSteerAngle;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;  // Set the center of mass to prevent tipping
    }

    void Update()
    {
        // Get input for driving
        float moveInput = Input.GetAxis("Vertical");  // W/S or Up/Down Arrow
        float steerInput = Input.GetAxis("Horizontal");  // A/D or Left/Right Arrow

        // Accelerate and steer
        AccelerateCar(moveInput);
        SteerCar(steerInput);

        // Apply braking if needed
        if (Input.GetKey(KeyCode.Space))  // Spacebar for brake
        {
            BrakeCar();
        }

        // Keep the car within a speed limit
        LimitSpeed();
    }

    private void AccelerateCar(float moveInput)
    {
        currentSpeed = rb.velocity.magnitude;

        // Apply force to move the car forward and backward
        if (moveInput != 0 && currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput * acceleration * Time.deltaTime);
        }
    }

    private void SteerCar(float steerInput)
    {
        currentSteerAngle = steeringAngle * steerInput;
        transform.Rotate(0f, currentSteerAngle * Time.deltaTime, 0f);  // Apply steering
    }

    private void BrakeCar()
    {
        rb.drag = brakeForce * Time.deltaTime;  // Increase drag to slow down
    }

    private void LimitSpeed()
    {
        // Ensure the car's speed doesn't exceed maxSpeed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
