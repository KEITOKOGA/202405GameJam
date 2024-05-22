using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void OnClickSceneLoad()
    {
        SceneManager.LoadScene("kasaharaScene");
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("");
    }

}
