using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class TestPlayer : MonoBehaviour
{
    private float _clearTime; // ゲームのクリア時間

    // ゲーム終了時に呼び出すメソッド
    public void GameOver()
    {
        // クリア時間を取得
        _clearTime = Time.timeSinceLevelLoad;

        // PlayFabにクリア時間を送信
        UpdatePlayerStatistics("ClearTime", (int)_clearTime);
    }

    // PlayFabにプレイヤーの統計情報を更新するメソッド
    private void UpdatePlayerStatistics(string statisticName, int statisticValue)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = statisticName,
                    Value = statisticValue
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticsSuccess, OnUpdatePlayerStatisticsError);
    }

    // 統計情報の更新が成功した時の処理
    private void OnUpdatePlayerStatisticsSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("クリア時間の更新に成功しました。");
    }

    // 統計情報の更新が失敗した時の処理
    private void OnUpdatePlayerStatisticsError(PlayFabError error)
    {
        Debug.LogError("クリア時間の更新に失敗しました。");
        Debug.LogError(error.GenerateErrorReport());
    }
}