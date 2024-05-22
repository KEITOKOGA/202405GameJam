using takechi;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("追いかけ始める範囲")] private float _searchRadius = 3f;
    [SerializeField, Header("ゲームオーバーシーンの名前")] private string _gameOverSceneName;
    private NavMeshAgent _agent;
    private Transform _target;
    public float SearchRadius => _searchRadius;
    void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        var distance = _target.position - transform.position;
        if (distance.sqrMagnitude < _searchRadius * _searchRadius)
        {
            if (_agent.isStopped)
            {
                _agent.Resume();
            }
            _agent.SetDestination(_target.position);
        }
        else
        {
            _agent.Stop();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySE(3);
            SceneManager.LoadScene(_gameOverSceneName);
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    private Enemy enemy;
        
    public void OnSceneGUI () 
    {
        enemy = target as Enemy;
        Handles.color = Color.red;
        Handles.DrawWireDisc(enemy.transform.position +(enemy.transform.forward *enemy.SearchRadius)
            , enemy.transform.forward, enemy.SearchRadius);                   
    }
}
#endif