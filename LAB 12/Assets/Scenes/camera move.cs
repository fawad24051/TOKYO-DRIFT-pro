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
