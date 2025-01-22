using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int CoinCount;
    public Text CoinCountText;
    public Transform RampObject;
    float current, startYPosition;

    private void Start()
    {
        startYPosition = RampObject.position.y;
    }


    void Update()
    {
        CoinCountText.text = "�~ " + CoinCount.ToString();

        // �R�C����5�W�߂���Q�[�g���J��
        if (CoinCount == 5)
        {
            
            RampObject.position = new Vector3(RampObject.position.x, (float)(startYPosition + 2.1), RampObject.position.z);
        }
    }
}
