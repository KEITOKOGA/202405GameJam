using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] private CameraShake _shakeCamera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("aaaaaa");
            _shakeCamera.Shake(2f, 5f);
        }
    }
}