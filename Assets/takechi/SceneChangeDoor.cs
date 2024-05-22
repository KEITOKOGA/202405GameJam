using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDoor : MonoBehaviour
{
    public static HashSet<string> UnlockedDoors = new();
    [SerializeField, Header("移動先のシーンでプレイヤーが立っている座標")] private Vector2 _position;
    [SerializeField, Header("移動先のシーン")] private string _moveToSceneName;
    [SerializeField, Header("鍵がかかっているかどうか")] private bool _isLocked = false;
    [SerializeField, Header("開ける時に鍵を消費するかどうか")] private bool _consumeKey = true;
    [SerializeField, Header("ドアを識別するための重複しないID")] string _doorID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (UnlockedDoors.Contains(_doorID) || !_isLocked)
            {
                Move();
            }
            else if (Player_Item._keyCount > 0)
            {
                if(_consumeKey) Player_Item._keyCount--;
                UnlockedDoors.Add(_doorID);
                Move();
            }
        }
    }

    void Move()
    {
        SceneChangeDispatcher.Instance.InitialPlayerPosition = new Vector3(_position.x, _position.y, 0);
        SceneChangeDispatcher.Instance.ChangePlayerPosition = true;
        SceneManager.LoadScene(_moveToSceneName);
    }
}
