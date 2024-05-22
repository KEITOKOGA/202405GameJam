using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnClickSceneLoad(string sceneName)
    {
        TimeManager.currentTime = 0;
        SceneManager.LoadScene(sceneName);
    }
}
