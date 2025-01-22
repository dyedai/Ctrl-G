using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameClearText;
    private bool isBlinking = false; // 点滅状態のフラグ
    public Transform RampObject;
    float current, startYPosition;
    private void Start()
    {
        startYPosition = RampObject.position.y;
    }

    void Update()
    {
        // ハートを3つ集めたらゲームクリアのテキストを表示して点滅開始
        if (HeartManager.heartCount == 3 && !isBlinking)
        {
            StartCoroutine(BlinkGameClearText());
            RampObject.position = new Vector3(RampObject.position.x, (float)(startYPosition + 2.1), RampObject.position.z); //修正前：startYPosition + 3
        }
    }

    IEnumerator BlinkGameClearText()
    {
        isBlinking = true;

        while (true)
        {
            // 表示
            gameClearText.SetActive(true);
            yield return new WaitForSeconds(0.5f); // 0.5秒待機

            // 非表示
            gameClearText.SetActive(false);
            yield return new WaitForSeconds(0.5f); // 0.5秒待機
        }
    }
}
