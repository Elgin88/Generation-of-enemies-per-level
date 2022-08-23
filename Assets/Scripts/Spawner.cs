using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;    
    [SerializeField] private float _delay;

    private SpawnPoint [] _spawnPoints;
    private SpawnPoint _currentSpawnPoint;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();               
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            InstantiateEnemy(_enemy, _currentSpawnPoint);
            yield return new WaitForSeconds(_delay);
        }        
    }

    private void InstantiateEnemy(Enemy enemy, SpawnPoint spawnPoint)
    {
        Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
    }
}
