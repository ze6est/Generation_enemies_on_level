using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnPoints;
    private int _numberSpawnPoint;
    private int _maxNumberSpawnPoint;
    private float _delay = 2f;    
    private bool _isSpawnerActive = true;

    private void Awake()
    {
        _spawnPoints = GetTransformInChildren();
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

            yield return waitForSeconds;
        }        
    }
    
    private Transform[] GetTransformInChildren()
    {
        List<Transform> transforms = new List<Transform>();

        foreach(Transform childrenTransform in transform)
        {
            transforms.Add(childrenTransform);
        }

        Transform[] childrenTransforms = transforms.ToArray();
        return childrenTransforms;
    }
}