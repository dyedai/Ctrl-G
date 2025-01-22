using UnityEngine;
using TMPro; // TextMeshPro�p
using System; // TimeSpan�p

public class StageFinalManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro ClearTimeText; // 3D TextMeshPro�p�̎Q��

    private void Start()
    {
        // �^�C�}�[���~
        GameTimer.StopTimer();

        // h:m:s�`���ŕ\��
        ClearTimeText.text = $"Clear Time: {GameTimer.GetFormattedTime()}";
    }
}
