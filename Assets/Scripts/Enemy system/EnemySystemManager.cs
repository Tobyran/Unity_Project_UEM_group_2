using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private Transform[] positions;
    [SerializeField] private Transform enemyPool;
    [SerializeField] private float timeBetweenEnemies;
    [SerializeField] private float enemyOffset;
    [SerializeField] private int maxActiveEnemies = 5; 

    private void Start()
    {
        AddEnemyToPool(numberOfEnemies);
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private void AddEnemyToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject stump = Instantiate(enemyPrefab);
            stump.SetActive(false);
            enemyList.Add(stump);
            stump.transform.parent = enemyPool;
        }
    }

    public GameObject RequestEnemy()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeSelf)
            {
                enemyList[i].SetActive(true);
                return enemyList[i];
            }
        }
        AddEnemyToPool(1);
        enemyList[enemyList.Count - 1].SetActive(true);
        return enemyList[enemyList.Count - 1];
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            if (CountActiveEnemies() < maxActiveEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = RequestEnemy();

        int randomInt = Random.Range(0, positions.Length);
        enemy.transform.position = positions[randomInt].position + Vector3.left * enemyOffset;
    }

    private int CountActiveEnemies()
    {
        int activeCount = 0;
        foreach (GameObject enemy in enemyList)
        {
            if (enemy.activeSelf)
            {
                activeCount++;
            }
        }
        return activeCount;
    }
}
