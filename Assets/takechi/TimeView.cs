using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private bool _updateText = true;

    private void Start()
    {
        _timeText.text = TimeManager.currentTime.ToString();
    }

    private void Update()
    {
        if (_updateText)
        {
            _timeText.text = TimeManager.currentTime.ToString();
        }
    }
}
