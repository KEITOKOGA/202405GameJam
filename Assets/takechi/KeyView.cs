using UnityEngine;
using UnityEngine.UI;

public class KeyView : MonoBehaviour
{
    [SerializeField] private Text _doorKeyCountText;
    [SerializeField] private Text _entranceDoorKeyCountText;
    void Start()
    {
        _doorKeyCountText.text = $"x {Player_Item._keyCount}";
        _entranceDoorKeyCountText.text = $"x {Player_Item.EntranceKeyCount}";
    }

    void Update()
    {
        _doorKeyCountText.text = $"x {Player_Item._keyCount}";
        _entranceDoorKeyCountText.text = $"x {Player_Item.EntranceKeyCount}";
    }
}
