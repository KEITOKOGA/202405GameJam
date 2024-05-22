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
        var saveData = SaveManager.Instance.LoadTime();
        rankingText.text = "";
        if (saveData == null)
        {
            rankingText.text = "No Data";
        }
        else
        {
            int count = 1;
            foreach (var record in saveData.ClearRecords)
            {
                rankingText.text += count + ". " + FormatTime(record) + "\n";
                if (count >= 3)
                {
                    break;
                }

                count++;
            }
        }
    }

    private string FormatTime(float time)
    {
        var minutes = (int)(time / 60f);
        var seconds = (int)(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
