using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameClearText;
    private bool isBlinking = false; // �_�ŏ�Ԃ̃t���O
    public Transform RampObject;
    float current, startYPosition;
    private void Start()
    {
        startYPosition = RampObject.position.y;
    }

    void Update()
    {
        // �n�[�g��3�W�߂���Q�[���N���A�̃e�L�X�g��\�����ē_�ŊJ�n
        if (HeartManager.heartCount == 3 && !isBlinking)
        {
            StartCoroutine(BlinkGameClearText());
            RampObject.position = new Vector3(RampObject.position.x, (float)(startYPosition + 2.1), RampObject.position.z); //�C���O�FstartYPosition + 3
        }
    }

    IEnumerator BlinkGameClearText()
    {
        isBlinking = true;

        while (true)
        {
            // �\��
            gameClearText.SetActive(true);
            yield return new WaitForSeconds(0.5f); // 0.5�b�ҋ@

            // ��\��
            gameClearText.SetActive(false);
            yield return new WaitForSeconds(0.5f); // 0.5�b�ҋ@
        }
    }
}
