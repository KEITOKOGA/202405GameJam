using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    public Text rankingText;

    private void OnEnable()
    {
        ShowRanking();
    }

    private void ShowRanking()
    {
        var times = new List<float>();

        // ランキングに表示するデータを読み込む
        for (var i = 0; i < 3; i++)
        {
            var time = SaveManager.Instance.LoadTime(i);
            if (time > 0)
            {
                times.Add(time);
            }
        }

        // 時間の短い順にソート
        times.Sort();

        // ランキングのテキストを更新
        rankingText.text = "";
        for (var i = 0; i < times.Count; i++)
        {
            rankingText.text += (i + 1) + ". " + times[i] + "\n";
        }
    }

    private string FormatTime(float time)
    {
        var minutes = (int)(time / 60);
        var seconds = (int)(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
