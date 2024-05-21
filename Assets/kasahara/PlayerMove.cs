using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerMove
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            Vector2 _move = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                _move.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _move.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                _move.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _move.y = -1;
            }

            _move.Normalize();

            GetComponent<Rigidbody2D>().velocity = speed * _move;
        }
    }
}