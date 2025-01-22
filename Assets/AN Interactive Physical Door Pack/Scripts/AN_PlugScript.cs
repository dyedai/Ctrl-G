
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_PlugScript : MonoBehaviour
{
    
    [Tooltip("Feature for one using only")]
    public bool OneTime = false;
    [Tooltip("Plug follow this local EmptyObject")]
    public Transform HeroHandsPosition;
    [Tooltip("SocketObject with collider(shpere, box etc.) (is trigger = true)")]
    public Collider Socket; // need Trigger
    //public AN_DoorScript DoorObject;
    public Transform RampObject;
    float current, startYPosition;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    bool follow = false, isConnected = false, followFlag = false, youCan = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startYPosition = RampObject.position.y;
    }

    void Update()
    {
        if (youCan) Interaction();

        // frozen if it is connected to PowerOut
        if (isConnected)
        {
            gameObject.transform.position = Socket.transform.position;
            gameObject.transform.rotation = Socket.transform.rotation;

        }

    }

    void Interaction()
    {
        if (NearView() && Input.GetKeyDown(KeyCode.F) && !follow)
        {
            isConnected = false; // unfrozen
            follow = true;
            followFlag = false;
        }

        if (follow)
        {
            rb.drag = 10f;
            rb.angularDrag = 10f;
            if (followFlag)
            {
                distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                if (distance > 5f || Input.GetKeyDown(KeyCode.F))
                {
                    follow = false;
                }
            }

            followFlag = true;
            rb.AddExplosionForce(-1000f, HeroHandsPosition.position, 10f);
            // second variant of following
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, objectLerp.position, 1f);
        }
        else
        {
            rb.drag = 0f;
            rb.angularDrag = .5f;
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 5f && angleView < 35f) return true;
        else return false;
        // RampObject.position = new Vector3(RampObject.position.x, startYPosition + 3, RampObject.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Socket)
        {
            isConnected = true;
            follow = false;


            RampObject.position = new Vector3(RampObject.position.x, startYPosition + 3, RampObject.position.z);


        }
        if (OneTime) youCan = false;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AN_PlugScript : MonoBehaviour
//{
//    public AudioSource audioSource;
//    public AudioClip SE;
//    [Tooltip("Feature for one using only")]
//    public bool OneTime = false;
//    [Tooltip("SocketObject with collider (is trigger = true)")]
//    public Collider Socket; // Must be a trigger
//    [Tooltip("Player's hand collider")]
//    public Collider PlayerHand; // Player hand collider
//    public Transform RampObject;

//    private float startYPosition;
//    private bool isConnected = false, youCan = true;
//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        startYPosition = RampObject.position.y;
//    }

//    void Update()
//    {
//        if (youCan && !isConnected) Interaction();

//        if (isConnected)
//        {
//            // Maintain position and rotation if connected
//            gameObject.transform.position = Socket.transform.position;
//            gameObject.transform.rotation = Socket.transform.rotation;

//            // Allow disconnection with F key
//            if (NearView() && Input.GetKeyDown(KeyCode.E))
//            {
//                DisconnectFromSocket();
//            }
//        }
//    }

//    void Interaction()
//    {
//        if (NearView() && Input.GetMouseButtonDown(0)) // Left-click interaction
//        {
//            // Check if playerHand is in contact with the socket
//            if (IsPlayerHandNearSocket())
//            {
//                audioSource.PlayOneShot(SE);
//                ConnectToSocket();
//            }
//        }
//    }

//    void ConnectToSocket()
//    {
//        isConnected = true;

//        // Move RampObject upwards
//        RampObject.position = new Vector3(RampObject.position.x, (float)(startYPosition + 2.1), RampObject.position.z);

//        if (OneTime) youCan = false;

//        // Disable Rigidbody to prevent physics interference
//        if (rb != null) rb.isKinematic = true;
//    }

//    void DisconnectFromSocket()
//    {
//        isConnected = false;

//        // Reset RampObject position
//        RampObject.position = new Vector3(RampObject.position.x, startYPosition, RampObject.position.z);

//        // Re-enable Rigidbody for normal physics
//        if (rb != null) rb.isKinematic = false;
//    }

//    bool NearView() // Check if near interactive object
//    {
//        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
//        Vector3 direction = transform.position - Camera.main.transform.position;
//        float angleView = Vector3.Angle(Camera.main.transform.forward, direction);

//        return distance < 5f && angleView < 35f;
//    }

//    bool IsPlayerHandNearSocket()
//    {
//        // Check if playerHand is in contact with the socket collider
//        return PlayerHand.bounds.Intersects(Socket.bounds);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other == Socket && !isConnected)
//        {
//            // Optionally: Automatically connect when entering the socket (if required)
//            // ConnectToSocket();
//        }
//    }
//}

