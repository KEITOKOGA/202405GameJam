using UnityEngine;
using UnityEngine.SceneManagement;

namespace takechi
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField, Header("ゲームクリアシーンの名前")]
        private string _gameClearSceneName;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && Player_Item.EntranceKeyCount > 0)
            {
                Player_Item.EntranceKeyCount--;
                SceneManager.LoadScene(_gameClearSceneName);
            }
        }
    }
}