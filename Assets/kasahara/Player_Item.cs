using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    public int keyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        string getTag = collision.gameObject.tag;
        Debug.Log(getTag);

            if(getTag == "Key")
                {
                    keyCount++;
                    collision.gameObject.SetActive(false);
                }
            if(getTag =="Door" &&  keyCount > 0)
                {
                    keyCount--;
                    collision.gameObject.SetActive(false);
                }
    }
}
