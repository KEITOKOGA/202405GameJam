using UnityEngine;

namespace takechi
{
    public class SceneChangeInitializer : MonoBehaviour
    {
        private void Awake()
        {
            _ = SceneChangeDispatcher.Instance;
        }
    }
}