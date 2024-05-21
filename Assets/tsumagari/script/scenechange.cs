using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
   public void OnClickSceneLoad()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene");
    }

}
