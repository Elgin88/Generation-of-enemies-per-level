using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _delay;

    private SpawnPoin [] _spawnPoints;
    private float _timeAfterLastSpawn;
    private SpawnPoin _currentSpawnPoint;
    private int _currentPointNumber;
    private int _previousPointNumber;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoin>();
        _timeAfterLastSpawn = _delay;
    }

    private void Update()
    {
        _timeAfterLastSpawn+= Time.deltaTime;

        while (_currentPointNumber == _previousPointNumber)
        {
            _currentPointNumber = Random.Range(0, _spawnPoints.Length);
        }       

        _currentSpawnPoint = _spawnPoints[_currentPointNumber];

        if (_timeAfterLastSpawn > _delay)
        {
            InstantiateEnemy(_enemy);
            _timeAfterLastSpawn = 0;
            _previousPointNumber = _currentPointNumber;
        }
    }

    private void InstantiateEnemy(Enemy enemy)
    {
        Instantiate(enemy, _currentSpawnPoint.transform.position, Quaternion.identity);
    }
}
