using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public delegate void EnemyTakeDamage(GameObject enemy);
    public EnemyTakeDamage enemyTakeDamage;
  
    void OnDestroy()
    {
        if(enemyTakeDamage!=null)
        {
            enemyTakeDamage(gameObject);
        }
    }
}
