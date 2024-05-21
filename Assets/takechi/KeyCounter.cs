using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = $"x {Player_Item._keyCount}";
    }

    void Update()
    {
        _text.text = $"x {Player_Item._keyCount}";
    }
}
