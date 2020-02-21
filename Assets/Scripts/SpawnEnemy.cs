using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] points;

    public EnemyWaveData[] enemyWaves;

    private GameControllerBehavior gameController;
    private int enemy_count=0;
    private bool wave_duration = false;

    private float lastSpawnTime;

 
    void Start()
    {
        
        lastSpawnTime = Time.time;
        gameController = GameObject.Find("GameController").GetComponent<GameControllerBehavior>();
        gameController.Max_count_Wave = enemyWaves.Length;
        StartCoroutine(New_Wave_label(1.2f));
        
    }

    void Update()
    {
        int current_wave = gameController.Wave;
        if(current_wave < enemyWaves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = enemyWaves[current_wave].Spawn_interval;
            if(((enemy_count==0 && timeInterval > enemyWaves[current_wave].Wave_duration) ||
                timeInterval >spawnInterval) && enemy_count < enemyWaves[current_wave].Enemy_count)
            {
                
                GameObject new_Enemy = (GameObject)Instantiate(enemy[Random.Range(0, enemy.Length)]);
                new_Enemy.GetComponent<Movement>().road_points = points;


                //reset timer & update current enemy count
                lastSpawnTime = Time.time;
                enemy_count++;
            }
            if(enemy_count == enemyWaves[current_wave].Enemy_count
                && GameObject.FindGameObjectWithTag("Enemy")==null)
            {
                StartCoroutine(New_Wave_label(1.2f));
                gameController.Wave++;
                enemy_count = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameController.lose = true;
        }
    }

    IEnumerator New_Wave_label(float time)
    {
        gameController.newWave_label.SetActive(true);
        yield return new WaitForSeconds(time);
        gameController.newWave_label.SetActive(false);

    }
}
