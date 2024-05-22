using UnityEngine;
using UnityEngine.SceneManagement;

namespace takechi
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField, Header("ゲームクリアシーンの名前")]
        private string _gameClearSceneName;
        [SerializeField, Header("脱出に必要な鍵の数")] private int _exitKeyCount = 2;

        private GameManager gameManager;
        private void Awake()
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && Player_Item.EntranceKeyCount >= _exitKeyCount)
            {
                AudioManager.Instance.PlaySE(0);
                AudioManager.Instance.PlaySE(1);
                Player_Item.EntranceKeyCount -= _exitKeyCount;
                if(gameManager) gameManager.Goal();
                SceneManager.LoadScene(_gameClearSceneName);
            }
        }
    }
}