using UnityEngine;

public class Player_Item : MonoBehaviour
{
    public static int _keyCount = 0;
    [SerializeField] GameObject _door;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string getTag = collision.gameObject.tag;
        Debug.Log(getTag);

        if (getTag == "Key")
        {
            _keyCount++;
            collision.gameObject.SetActive(false);
        }

        
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        string getTag = collision.gameObject.tag;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("ddd");
            if (getTag == "Door" && _keyCount > 0)
                _keyCount--;
                collision.gameObject.SetActive(false);
        }
    }
}
