using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemaChine;
    private float _shakeTimer;

    private void Awake()
    {
        _cinemaChine = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0f)
            {
                var cinemaChineBasicMultiChannelPerlin =
                    _cinemaChine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemaChineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    public void Shake(float timer, float intensity)
    {
        var cinemaChineBasicMultiChannelPerlin =
            _cinemaChine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemaChineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _shakeTimer = timer;
    }
    
    
}