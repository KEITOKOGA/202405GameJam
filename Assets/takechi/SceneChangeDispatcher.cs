using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDispatcher
{
    private static SceneChangeDispatcher _instance;
    public static SceneChangeDispatcher Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneChangeDispatcher();
            }

            return _instance;
        }
    }
    /// <summary>シーン読み込み後のプレイヤーの位置</summary>
    public Vector3 InitialPlayerPosition;
    /// <summary>シーン読み込み後にプレイヤーの位置を変えるかどうか</summary>
    public bool ChangePlayerPosition;

    SceneChangeDispatcher()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.FindWithTag("Player");
        if (player && ChangePlayerPosition)
        {
            player.transform.position = InitialPlayerPosition;
            ChangePlayerPosition = false;
        }
        
        //  初期化
        if (scene.name is "GameOver" or "GameClear" or "Title")
        {
            Player_Item._keyCount = 0;
            Player_Item.EntranceKeyCount = 0;
            Key.ObtainedKeys.Clear();
            SceneChangeDoor.UnlockedDoors.Clear();
        }
    }
}
