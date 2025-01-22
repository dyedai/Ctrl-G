using UnityEngine;

public class KeypadAction : MonoBehaviour
{
    public Transform RampObject;
    private float startYPosition;

    private void Start()
    {
        startYPosition = RampObject.position.y;
    }

    // RampObjectを上に動かす関数
    public void moveGate()
    {
        RampObject.position = new Vector3(RampObject.position.x, startYPosition + 2.1f, RampObject.position.z);
    }
}
