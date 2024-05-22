using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private bool _updateText = true;

    private void Start()
    {
        
        _timeText.text = FormatTime(TimeManager.currentTime);
    }

    private void Update()
    {
        if (_updateText)
        {
            _timeText.text = FormatTime(TimeManager.currentTime);
        }
    }
    private string FormatTime(float time)
    {
        var minutes = (int)(time / 60f);
        var seconds = (int)(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
