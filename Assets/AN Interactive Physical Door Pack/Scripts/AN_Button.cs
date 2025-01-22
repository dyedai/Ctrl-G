//using UnityEngine;

//public class AN_Button : MonoBehaviour
//{
//    [Tooltip("True for rotation like valve (used for ramp/elevator only)")]
//    public bool isValve = false;
//    [Tooltip("SelfRotation speed of valve")]
//    public float ValveSpeed = 10f;
//    [Tooltip("If it isn't valve, it can be lever or button (animated)")]
//    public bool isLever = false;
//    [Tooltip("If it is false door can't be used")]
//    public bool Locked = false;
//    [Tooltip("The door for remote control")]
//    public AN_DoorScript DoorObject;
//    [Space]
//    [Tooltip("Any object for ramp/elevator baheviour")]
//    public Transform RampObject;
//    [Tooltip("Door can be opened")]
//    public bool CanOpen = true;
//    [Tooltip("Door can be closed")]
//    public bool CanClose = true;
//    [Tooltip("Current status of the door")]
//    public bool isOpened = false;
//    [Space]
//    [Tooltip("True for rotation by X local rotation by valve")]
//    public bool xRotation = true;
//    [Tooltip("True for vertical movenment by valve (if xRotation is false)")]
//    public bool yPosition = false;
//    public float max = 90f, min = 0f, speed = 5f;
//    bool valveBool = true;
//    float current, startYPosition;
//    Quaternion startQuat, rampQuat;

//    Animator anim;

//    // NearView()
//    float distance;
//    float angleView;
//    Vector3 direction;

//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        startYPosition = RampObject.position.y;
//        startQuat = transform.rotation;
//        rampQuat = RampObject.rotation;
//    }

//    void Update()
//    {
//        if (!Locked)
//        {
//            if (Input.GetKeyDown(KeyCode.F) && !isValve && DoorObject != null && DoorObject.Remote && NearView()) // 1.lever and 2.button
//            {
//                DoorObject.Action(); // void in door script to open/close
//                if (isLever) // animations
//                {
//                    if (DoorObject.isOpened) anim.SetBool("LeverUp", true);
//                    else anim.SetBool("LeverUp", false);
//                }
//                else anim.SetTrigger("ButtonPress");
//            }
//            else if (isValve && RampObject != null) // 3.valve
//            {
//                // changing value in script
//                if (Input.GetKey(KeyCode.F) && NearView())
//                {
//                    if (valveBool)
//                    {
//                        if (!isOpened && CanOpen && current < max) current += speed * Time.deltaTime;
//                        if (isOpened && CanClose && current > min) current -= speed * Time.deltaTime;

//                        if (current >= max)
//                        {
//                            isOpened = true;
//                            valveBool = false;
//                        }
//                        else if (current <= min)
//                        {
//                            isOpened = false;
//                            valveBool = false;
//                        }
//                    }

//                }
//                else
//                {
//                    if (!isOpened && current > min) current -= speed * Time.deltaTime;
//                    if (isOpened && current < max) current += speed * Time.deltaTime;
//                    valveBool = true;
//                }

//                // using value on object
//                transform.rotation = startQuat * Quaternion.Euler(0f, 0f, current * ValveSpeed);
//                if (xRotation) RampObject.rotation = rampQuat * Quaternion.Euler(current, 0f, 0f); // I have a doubt in working correctly
//                else if (yPosition) RampObject.position = new Vector3(RampObject.position.x, startYPosition + current, RampObject.position.z);
//            }
//        }
//    }

//    bool NearView() // it is true if you near interactive object
//    {
//        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
//        direction = transform.position - Camera.main.transform.position;
//        //Debug.Log(distance);
//        //Debug.Log(direction);
//        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
//        if (angleView < 45f && distance < 5f) return true;
//        else return false;
//    }
//}


//レバーを修正
using UnityEngine;

public class AN_Button : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip SE;
    [Tooltip("True for rotation like valve (used for ramp/elevator only)")]
    public bool isValve = false;
    [Tooltip("SelfRotation speed of valve")]
    public float ValveSpeed = 10f;
    [Tooltip("If it isn't valve, it can be lever or button (animated)")]
    public bool isLever = false;
    [Tooltip("If it is false door can't be used")]
    public bool Locked = false;
    [Tooltip("The door for remote control")]
    public AN_DoorScript DoorObject;
    [Space]
    [Tooltip("Any object for ramp/elevator behaviour")]
    public Transform RampObject;
    [Tooltip("Door can be opened")]
    public bool CanOpen = true;
    [Tooltip("Door can be closed")]
    public bool CanClose = true;
    [Tooltip("Current status of the door")]
    public bool isOpened = false;
    [Space]
    [Tooltip("True for rotation by X local rotation by valve")]
    public bool xRotation = true;
    [Tooltip("True for vertical movement by valve (if xRotation is false)")]
    public bool yPosition = false;
    public float max = 90f, min = 0f, speed = 5f;

    bool valveBool = true;
    bool leverUp = false; // レバーの状態
    float current, startYPosition;
    Quaternion startQuat, rampQuat;

    Animator anim;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (RampObject != null)
        {
            startYPosition = RampObject.position.y;
            rampQuat = RampObject.rotation;
        }
        startQuat = transform.rotation;
    }

    void Update()
    {
        if (!Locked)
        {
            if (Input.GetKeyDown(KeyCode.E) && NearView())
            {
                if (isLever) // レバーの操作
                {
                    leverUp = !leverUp; // 状態を切り替え
                    anim.SetBool("LeverUp", leverUp);

                    //    if (leverUp)
                    //    {
                    //        // レバーが上がった時の動作
                    //        RampObject.position = new Vector3(
                    //            RampObject.position.x,
                    //            startYPosition + 3,
                    //            RampObject.position.z
                    //        );
                    //    }
                    //    else
                    //    {
                    //        // レバーが下がった時の動作
                    //        RampObject.position = new Vector3(
                    //            RampObject.position.x,
                    //            startYPosition,
                    //            RampObject.position.z
                    //        );
                    //    }
                    //}
                    if (leverUp)
                {
                    audioSource.PlayOneShot(SE);
                    float newYPosition = (float)(startYPosition + 2.1);
                    RampObject.position = new Vector3(RampObject.position.x, newYPosition, RampObject.position.z);
                    Debug.Log($"レバーが上がり、柵が上に移動: {RampObject.position}");
                }
                else
                {
                    audioSource.PlayOneShot(SE);
                    RampObject.position = new Vector3(RampObject.position.x, startYPosition, RampObject.position.z);
                    Debug.Log($"レバーが下がり、柵が元の位置に戻る: {RampObject.position}");
                }
            }

            else if (DoorObject != null && DoorObject.Remote) // ボタンの動作
            {
                DoorObject.Action();
                anim.SetTrigger("ButtonPress");
            }
            }
            else if (isValve && RampObject != null) // バルブの操作
            {
                if (Input.GetKey(KeyCode.E) && NearView())
                {
                    if (valveBool)
                    {
                        if (!isOpened && CanOpen && current < max) current += speed * Time.deltaTime;
                        if (isOpened && CanClose && current > min) current -= speed * Time.deltaTime;

                        if (current >= max)
                        {
                            isOpened = true;
                            valveBool = false;
                        }
                        else if (current <= min)
                        {
                            isOpened = false;
                            valveBool = false;
                        }
                    }
                }
                else
                {
                    if (!isOpened && current > min) current -= speed * Time.deltaTime;
                    if (isOpened && current < max) current += speed * Time.deltaTime;
                    valveBool = true;
                }

                transform.rotation = startQuat * Quaternion.Euler(0f, 0f, current * ValveSpeed);
                if (xRotation) RampObject.rotation = rampQuat * Quaternion.Euler(current, 0f, 0f);
                else if (yPosition) RampObject.position = new Vector3(RampObject.position.x, startYPosition + current, RampObject.position.z);
            }
        }
    }

    bool NearView() // 近くにいるか判定
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return angleView < 45f && distance < 5f;
    }
}
