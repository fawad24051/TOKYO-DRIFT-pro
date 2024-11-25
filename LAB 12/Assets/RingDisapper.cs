using UnityEngine;

public class SpeedRingPickup : MonoBehaviour
{
    public float speedMultiplier = 3f; // speed increase factor
    public float boostDuration = 10f; // duration of the boost in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // check if the car collides with the ring
        {
            Debug.Log("Speed Ring Collected!");

            CarSpeed carSpeed = other.GetComponent<CarSpeed>();
            if (carSpeed != null)
            {
                StartCoroutine(carSpeed.ApplySpeedBoost(speedMultiplier, boostDuration));
            }

            Destroy(gameObject); // remove the ring from the scene
        }
    }
}

