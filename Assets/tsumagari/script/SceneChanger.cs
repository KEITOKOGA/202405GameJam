using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OnClickSceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
