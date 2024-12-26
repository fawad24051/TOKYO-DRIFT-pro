//using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
//public class SimpleCollectibleScript : MonoBehaviour
//{

//    public enum CollectibleTypes { NoType, Type1, Type2, Type3, Type4, Type5 }; // you can replace this with your own labels for the types of collectibles in your game!

//    public CollectibleTypes CollectibleType; // this gameObject's type

//    public bool rotate; // do you want it to rotate?

//    public float rotationSpeed;

//    public AudioClip collectSound;

//    public GameObject collectEffect;

//    public int points = 1; // points for collecting this item

//    private ScoreManager scoreManager; // reference to the score manager

//    // Use this for initialization
//    void Start()
//    {
//        scoreManager = FindObjectOfType<ScoreManager>(); // find the ScoreManager in the scene
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (rotate)
//            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {  // check if the player hits the coin
//            Collect();  // collect the item
//        }
//    }

//    public void Collect()
//    {
//        if (collectSound)
//            AudioSource.PlayClipAtPoint(collectSound, transform.position);  // play collection sound
//        if (collectEffect)
//            Instantiate(collectEffect, transform.position, Quaternion.identity);  // show collection effect

//        // Update the score
//        if (scoreManager != null)
//        {
//            scoreManager.AddScore(points);  // Add points to the score
//        }

//        // Destroy the collectible
//        Destroy(gameObject);
//    }
//}

