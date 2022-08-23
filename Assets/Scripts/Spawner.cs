using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;    
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;

    private SpawnPoint [] _spawnPoints;
    private SpawnPoint _currentSpawnPoint; 
    private float _timeAfterLastSpawn;    
    
    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _timeAfterLastSpawn = _delay;        
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _timeAfterLastSpawn += Time.deltaTime;
            _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            if (_timeAfterLastSpawn > _delay)
            {
                InstantiateEnemy(_enemy);
                _timeAfterLastSpawn = 0;                
            }

            yield return null;
        }        
    }

    private void InstantiateEnemy(Enemy enemy)
    {
        Instantiate(enemy, _currentSpawnPoint.transform.position, Quaternion.identity);
    }
}
