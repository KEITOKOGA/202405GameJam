
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    public static float currentTime;
    private Text currentTimeText;
    private Text fastestTimeText;
    private static float fastestTime = 999.999f;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeText = transform.Find("Text").GetComponent<Text>();
        //　最速タイムを表示
        fastestTimeText = transform.Find("Text").GetComponent<Text>();
        fastestTimeText.text = fastestTime.ToString("0.000");
    }

    // Update is called once per frame
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
