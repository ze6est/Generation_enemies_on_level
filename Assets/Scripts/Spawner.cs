using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private SpawnPoint[] _spawnPoints;
    private int _numberSpawnPoint;
    private int _maxNumberSpawnPoint;
    private float _delay = 2f;    
    private bool _isSpawnerActive = true;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _maxNumberSpawnPoint = _spawnPoints.Length;
    }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (_isSpawnerActive)
        {
            if (_numberSpawnPoint == _maxNumberSpawnPoint)
                _numberSpawnPoint = 0;

            Instantiate(_enemy, _spawnPoints[_numberSpawnPoint].transform.position, Quaternion.identity);
            _numberSpawnPoint++;

            yield return new waitForSeconds;
        }        
    }    
}
