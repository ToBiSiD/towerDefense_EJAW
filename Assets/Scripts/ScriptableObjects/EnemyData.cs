using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy/Standart Enemy",fileName="New Enemy")]
public class EnemyData : ScriptableObject
{
    [Tooltip("Enemy GameObject")]
    [SerializeField] private GameObject enemyObject;
    public GameObject EnemyObject
    {
        get { return enemyObject; }
        protected set { }
    }

    [Tooltip("health amount")]
    [SerializeField] private float health_amount;
    public float Health_amount
    {
        get { return health_amount; }
        protected set { }
    }

    [Tooltip("MoveSpeed")]
    [SerializeField] private float move_speed;
    public float Move_speed
    {
        get { return move_speed; }
        protected set { }
    }

    [Tooltip("Enemy damage")]
    [SerializeField] private int enemy_damage;
    public int enemy_Damage
    {
        get { return enemy_damage; }
        protected set { }
    }
}
