using UnityEngine;
using TMPro; // TextMeshPro用
using System; // TimeSpan用

public class StageFinalManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro ClearTimeText; // 3D TextMeshPro用の参照

    private void Start()
    {
        // タイマーを停止
        GameTimer.StopTimer();

        // h:m:s形式で表示
        ClearTimeText.text = $"Clear Time: {GameTimer.GetFormattedTime()}";
    }
}
