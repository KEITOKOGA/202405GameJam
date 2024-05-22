using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public static float currentTime;
    private static float fastestTime = 999.999f;
    public SaveManager _saveManager;

    private void Start()
    {
        _saveManager = GetComponent<SaveManager>();
    }

    void Update()
    {
        //　ゴールしていなければ時間を計測
        if (!gameManager.IsFinished())
        {
            currentTime += Time.deltaTime;
        }
    }

    //　最高タイムの更新
    public void UpdateFastestTime()
    {
        if (currentTime < fastestTime)
        {
            fastestTime = currentTime;
            _saveManager.SaveTime(currentTime);
        }
    }
}
