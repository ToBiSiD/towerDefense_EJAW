using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave/Standart EnemyWave", fileName = "New EnemyWave")]
public class EnemyWaveData : ScriptableObject
{
    [Tooltip("Wave`s duration")]
    [SerializeField] private float wave_duration;
    public float Wave_duration
    {
        get { return wave_duration; }
        protected set { }
    }


    [Tooltip("enemyCount")]
    [SerializeField] private int enemy_count;
    public int Enemy_count
    {
        get { return enemy_count; }
        protected set { }
    }

    [Tooltip("Interval for enemy spawn")]
    [SerializeField] private float spawn_interval;
    public float Spawn_interval
    {
        get { return spawn_interval; }
        protected set { }
    }
}
