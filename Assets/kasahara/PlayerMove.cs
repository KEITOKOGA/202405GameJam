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
            if (_move != Vector2.zero)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(_move.x, _move.y, 0));
            }
            GetComponent<Rigidbody2D>().velocity = speed * _move;
        }
    }
}