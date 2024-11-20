/*
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float raycastDistance = 2.0f; // Increased raycast distance for bumps
    public float hoverHeight = 0.7f; // Adjust hover height above the road
    public LayerMask trackLayer; // Layer mask to identify the track

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Prevent tipping
    }

    void Update()
    {
        // Movement and rotation
        Vector3 forwardMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            forwardMovement += transform.forward * moveSpeed * Time.deltaTime;
            Debug.Log("W key is held down");
        }
        if (Input.GetKey(KeyCode.S))
        {
            forwardMovement -= transform.forward * moveSpeed * Time.deltaTime;
            Debug.Log("S key is held down");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -moveSpeed * 2f * Time.deltaTime); // Rotate left
            Debug.Log("A key is held down");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, moveSpeed * 2f * Time.deltaTime); // Rotate right
            Debug.Log("D key is held down");
        }

        // Apply movement
        rb.MovePosition(rb.position + forwardMovement);

        // Align the car to the track
        AlignToTrack();
    }

    void AlignToTrack()
    {
        // Cast a ray downward from above the car to detect the road
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        RaycastHit hit;

        // Debug ray visualization
        Debug.DrawRay(transform.position + Vector3.up, Vector3.down * raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, raycastDistance, trackLayer))
        {
            // Adjust car's position to maintain hover height
            Vector3 targetPosition = hit.point + Vector3.up * hoverHeight;
            rb.MovePosition(new Vector3(rb.position.x, targetPosition.y, rb.position.z));
        }
    }
}
*/

/*
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    // Movement speed
    public float moveSpeed = 5f;

    void Update()
    {
        // Detect specific key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
        }

        // Check if W key is held down (Move Forward)
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            Debug.Log("W key is held down");
        }

        // Check if S key is held down (Move Backward)
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            Debug.Log("S key is held down");
        }

        // Check if A key is held down (Move Left)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            Debug.Log("A key is held down");
        }

        // Check if D key is held down (Move Right)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            Debug.Log("D key is held down");
        }

        // Check if W key was released
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("W key released");
        }
    }
}
*/

/*
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 50f; // Rotation speed

    void Update()
    {
        // Movement logic
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

        // Add rotation when turning
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime); // Rotate left
            Debug.Log("A key is held down");
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime); // Rotate right
            Debug.Log("D key is held down");
        }
    }
}
*/


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
