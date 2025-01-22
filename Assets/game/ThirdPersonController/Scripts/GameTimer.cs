using UnityEngine;
using System;

public static class GameTimer
{
    private static float _totalPlayTime = 0f;  // �v���C�x�[�g�ϐ��ɕύX
    private static bool _isTimerRunning = false;

    // �v���p�e�B��ʂ��ăA�N�Z�X
    public static float TotalPlayTime
    {
        get { return _totalPlayTime; }
        private set { _totalPlayTime = value; }
    }

    public static bool IsTimerRunning
    {
        get { return _isTimerRunning; }
        private set { _isTimerRunning = value; }
    }

    public static void StartTimer()
    {
        IsTimerRunning = true;
        // �f�o�b�O���O��ǉ�
        Debug.Log("Timer Started");
    }

    public static void StopTimer()
    {
        IsTimerRunning = false;
        TotalPlayTime = Mathf.Round(TotalPlayTime * 100f) / 100f;
        //Debug.Log("Timer Stopped. Total time: " + TotalPlayTime);
    }

    public static void ResetTimer()
    {
        TotalPlayTime=0f;
    }

    public static void UpdateTimer()
    {
        if (IsTimerRunning)
        {
            TotalPlayTime += Time.unscaledDeltaTime;
            // �f�o�b�O�p�F1�b���ƂɎ��Ԃ�\��
            //if (TotalPlayTime % 1 < Time.unscaledDeltaTime)
            //{
            //    Debug.Log($"Current time: {GetFormattedTime()}");
            //}
        }
    }

    public static string GetFormattedTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(TotalPlayTime);
        return string.Format("{0:D2}h {1:D2}m {2:D2}s",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
}