using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveTime(float time)
    {
        for (var i = 0; i < 3; i++)
        {
            var savedTime = PlayerPrefs.GetFloat("ClearTime" + i, 999.999f);
            if (time < savedTime)
            {
                PlayerPrefs.SetFloat("ClearTime" + i, time);
                PlayerPrefs.Save();
                return;
            }
        }
    }

    public float LoadTime(int index)
    {
        return PlayerPrefs.GetFloat("ClearTime" + index, 999.999f);
    }
}