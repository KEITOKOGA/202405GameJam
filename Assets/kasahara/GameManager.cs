
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

    }

    public void Goal()
    {
        finished = true;
        //　ゴール用テキスト表示
        InstantiateMessage("ESCAPE！！");
        //　最高タイムの更新
        timeManager.UpdateFastestTime();
    }

    //　ゲームを終了したかどうか
    public bool IsFinished()
    {
        return finished;
    }

    //　ゲーム内メッセージを表示
    public void InstantiateMessage(string message)
    {
        var ins = Instantiate<GameObject>(textPrefab);
        ins.GetComponentInChildren<Text>().text = message;
    }
}
