
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;

    private bool finished;

    void Start()
    {

    }

    public void Goal()
    {
        SaveManager.Instance.SaveTime(TimeManager.currentTime);
        finished = true;
        timeManager.UpdateFastestTime();
    }

    //　ゲームを終了したかどうか
    public bool IsFinished()
    {
        return finished;
    }

}
