using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
     WaveConfigSO currentWave;

    bool isLooping = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
          
            int randomIndex = Random.Range(0, waveConfigs.Length);
            WaveConfigSO waveConfig = waveConfigs[randomIndex];

            currentWave = waveConfig;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);

                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);

        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}


