using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveConfigSo> waveConfigs;

    [SerializeField]
    private float timeBetweenWaves;

    [SerializeField]
    private bool isLooping = true;

    private WaveConfigSo _currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSo GetCurrentWave()
    {
        return _currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (var waveConfig in waveConfigs)
            {
                _currentWave = waveConfig;
                yield return SpawnEnemies();
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }

            yield return new WaitForSecondsRealtime(5);
        } while (isLooping);
    }

    private IEnumerator SpawnEnemies()
    {
        for (var i = 0; i < _currentWave.GetEnemyCount(); i++)
        {
            Instantiate(
                _currentWave.GetEnemyPrefab(i),
                _currentWave.GetStartingWaypoint().position,
                Quaternion.Euler(0, 0, 180),
                transform
            );
            yield return new WaitForSecondsRealtime(_currentWave.GetRandomSpawnTime());
        }
    }
}
