using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private Text _leaderBoardText; //ランキングのText
    
    //PlayFabのPlayer登録
    private void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += PlayFabAuthService_OnPlayFabError;
    }

    //PlayFabのPlayerの解除
    private void OnDisable()
    {
        PlayFabAuthService.OnLoginSuccess -= PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError -= PlayFabAuthService_OnPlayFabError;
    }

    //サイレント認証を行う
    private void Start()
    {
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }

    private void PlayFabAuthService_OnLoginSuccess(LoginResult success)
    {
        Debug.Log("ログイン成功");
        GetLeaderboard();　//ログインが成功したらリーダーボードを取得
    }

    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("ログイン失敗");
    }
    
    private void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "ClearTime",　//取得するスタジオの名前
            StartPosition = 0,　
            MaxResultsCount = 3　//表示する結果の数
        }, result =>
        {
            var leaderboard = "Leaderboard:\n";
            //Scoreの表示
            foreach (var item in result.Leaderboard)
            {
                var displayName = item.DisplayName;　// プレイヤー名を取得
                if (displayName == null)
                {
                    displayName = "NoName";　// プレイヤー名がない場合は"NoName"を使用
                }
                leaderboard += $"{item.Position + 1}位: {displayName} - {item.StatValue}秒\n";　// リーダーボードのText UIに設定
            }
//            _leaderBoardText.text = leaderboard;
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
}