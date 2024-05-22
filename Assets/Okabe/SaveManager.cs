using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    
    public void SaveTime(float time)
    {
        for (var i = 0; i < 3; i++)
        {
            var savedTime = PlayerPrefs.GetFloat("ClearTime" + i, 999.999f);
            if (time < savedTime)
            {
                PlayerPrefs.SetFloat("ClearTime" + i, time);
                return;
            }
        }
    }

    public float LoadTime(int index)
    {
        return PlayerPrefs.GetFloat("ClearTime" + index, 999.999f);
    }
}