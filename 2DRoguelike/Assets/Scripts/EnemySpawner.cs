using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float spawnRate;
    private Vector3 spawnPos;

    private float x, y;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        x = Random.Range(-3, 3);
        y = Random.Range(-3, 3);
        spawnPos.x += x;
        spawnPos.y += y;
        Instantiate(Enemies[0], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemy());
    }
}
