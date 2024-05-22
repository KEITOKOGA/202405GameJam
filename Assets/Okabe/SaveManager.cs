using System.Collections.Generic;
using System.Linq;
using takechi;
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
        var data = LoadTime();
        if (data != null)
        {
            data.ClearRecords.Add(time);
        }
        else
        {
            data = new SaveData();
            data.ClearRecords.Add(time);
        }

        data.ClearRecords = data.ClearRecords.OrderBy(f=>f).ToList();

        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SaveData", json);
    }

    public SaveData LoadTime()
    {
        var json = PlayerPrefs.GetString("SaveData");
        return JsonUtility.FromJson<SaveData>(json);
    }
}