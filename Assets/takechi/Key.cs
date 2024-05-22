using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static HashSet<string> ObtainedKeys = new();
    [SerializeField] string _keyID;
    [SerializeField] private bool _isEntranceKey = false;

    private void Awake()
    {
        if (ObtainedKeys.Contains(_keyID))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player_Item _))
        {
            if (_isEntranceKey)
            {
                Player_Item.EntranceKeyCount++;
            }
            else
            {
                Player_Item._keyCount++;
            }
            gameObject.SetActive(false);
            ObtainedKeys.Add(_keyID);
        }
    }
}
