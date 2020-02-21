using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_healthBar : MonoBehaviour
{
    private float current_health;
    public float Current_health
    {
        get { return current_health; }
        set { current_health = value; }
    }
    private float max_health;
    private float scale;
    [SerializeField] private EnemyData enemy_data;
    public GameObject health_sprite;
    void Start()
    {
        max_health = enemy_data.Health_amount;
        Current_health = enemy_data.Health_amount;
        scale = health_sprite.transform.localScale.x;
       

    }

    // Update is called once per frame
    void Update()
    {
  
        health_sprite.transform.localScale = new Vector3((Current_health / max_health)*scale,
            health_sprite.transform.localScale.y, health_sprite.transform.localScale.z);
       
    }
}
