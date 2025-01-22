using UnityEngine;
using System;

public static class GameTimer
{
    private static float _totalPlayTime = 0f;  // プライベート変数に変更
    private static bool _isTimerRunning = false;

    // プロパティを通じてアクセス
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
        // デバッグログを追加
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
            // デバッグ用：1秒ごとに時間を表示
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