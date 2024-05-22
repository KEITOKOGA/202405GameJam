
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    public static float currentTime;
    private static float fastestTime = 999.999f;

    void Start()
    {

    }

    void Update()
    {
        //　ゴールしていなければ時間を計測
        if (!gameManager.IsFinished())
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
        }
    }

    //　最高タイムの更新
    public void UpdateFastestTime()
    {
        if (currentTime < fastestTime)
        {
            fastestTime = currentTime;
        }
    }
}
