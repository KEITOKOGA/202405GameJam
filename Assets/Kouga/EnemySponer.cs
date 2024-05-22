using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponer : MonoBehaviour
{
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_enemy,_spawnPoint.transform);
            Destroy(this.gameObject);
        }
    }
}
