
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //　スタート用テキストプレハブ
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    private TimeManager timeManager;

    private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateMessage("ゲームスタート");
    }

    public void Goal()
    {
        finished = true;
        //　ゴール用テキスト表示
        InstantiateMessage("ゴール！！");
        //　最高タイムの更新
        timeManager.UpdateFastestTime();
        StartCoroutine(ReStart());
    }

    //　ゲームを終了したかどうか
    public bool IsFinished()
    {
        return finished;
    }

    //　ゲームのリスタート
    IEnumerator ReStart()
    {
        //　3秒後にリスタート
        yield return new WaitForSeconds(3f);
        //　現在のシーンを再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //　ゲーム内メッセージを表示
    public void InstantiateMessage(string message)
    {
        var ins = Instantiate<GameObject>(textPrefab);
        ins.GetComponentInChildren<Text>().text = message;
    }
}
