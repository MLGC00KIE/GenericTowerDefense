using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private float timerIncrement;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private float timeBetweenWaves = 5f;
    [SerializeField]
    private float timeBeforeFirstWave = 30f;
    [SerializeField]
    private float timeBetweenEnemies = 0.2f;

    private float countdown;

    public Text waveCountDownText;

    [SerializeField]
    private int waveIndex = 0;

    private void Start()
    {
        countdown = timeBeforeFirstWave;
    }

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave()
    {
        waveIndex++;
        timeBetweenWaves += timerIncrement;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Transform enemy = Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
        enemy.gameObject.GetComponent<EnemyMovement>().speed = enemy.gameObject.GetComponent<EnemyMovement>().speed * waveIndex / 10;
        if ((enemy.gameObject.GetComponent<EnemyMovement>().speed = enemy.gameObject.GetComponent<EnemyMovement>().speed * waveIndex / 10) <= 5)
        {
            enemy.gameObject.GetComponent<EnemyMovement>().speed = 5f;
        } else
        {
            enemy.gameObject.GetComponent<EnemyMovement>().speed = enemy.gameObject.GetComponent<EnemyMovement>().speed * waveIndex / 10;
        }

    }
}
