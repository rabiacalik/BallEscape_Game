using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabEnemy;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    private int waveNumber = 1;
    public int enemyCount;

    private void Start() {
        Instantiate(powerupPrefab, GenerateSpawnPos(),powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    private void Update() {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //enemyCount = FindObjectsByType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    public Vector3 GenerateSpawnPos(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(prefabEnemy, GenerateSpawnPos(), prefabEnemy.transform.rotation);
        }
    }
}
