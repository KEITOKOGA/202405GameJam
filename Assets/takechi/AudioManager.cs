using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace takechi
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        [SerializeField] private List<AudioClip> _seList;
        [SerializeField] private List<AudioClip> _bgmList;
        [SerializeField] private AudioClip _footSteps;
        private List<(AudioSource, AudioClip)> _seTupleList = new();
        private AudioSource _bgmSource;
        private AudioSource _footStepsSource;
        private bool _playedFootSteps;
        private void Awake()
        {
            if (!Instance)
            {
                DontDestroyOnLoad(gameObject);
                foreach (var se in _seList)
                {
                    var audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                    _seTupleList.Add((audioSource, se));
                }
                _bgmSource = gameObject.AddComponent<AudioSource>();
                _bgmSource.playOnAwake = false;
                _bgmSource.loop = true;
                
                _footStepsSource = gameObject.AddComponent<AudioSource>();
                _footStepsSource.playOnAwake = false;
                _footStepsSource.loop = true;
                _footStepsSource.clip = _footSteps;
                SceneManager.sceneLoaded += OnSceneLoaded;
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySE(int index)
        {
            index = Mathf.Clamp(index, 0, _seList.Count - 1);
            var tuple = _seTupleList[index];
            tuple.Item1.PlayOneShot(tuple.Item2);
        }
        public void PlayBGM(int index)
        {
            index = Mathf.Clamp(index, 0, _seList.Count - 1);
            _bgmSource.clip = _bgmList[index];
            _bgmSource.Play();
        }

        public void StopBGM()
        {
            _bgmSource.Stop();
        }

        public void PlayFootSteps()
        {
            if (_playedFootSteps) return;
            _footStepsSource.Play();
            _playedFootSteps = true;
        }
        public void StopFootSteps()
        {
            _playedFootSteps = false;
            _footStepsSource.Stop();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _playedFootSteps = false;
            _footStepsSource.Stop();
            if (scene.name is "GameOver" or "GameClear" or "Title")
            {
                PlayBGM(0);
            }
        }
    }
}