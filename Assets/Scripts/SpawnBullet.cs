using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBullet : MonoBehaviour
{
    private float lastShoot;
    [SerializeField]private TowerData towerData;
    public GameObject bullet;
    public Transform startPosition;
    public List<GameObject> visible_Enemies;
    private CircleCollider2D range_collider;
   
    void Start()
    {
        range_collider = gameObject.GetComponent<CircleCollider2D>();
        range_collider.radius = towerData.tower_Range;
        lastShoot = Time.time;
        visible_Enemies = new List<GameObject>();
        bullet.GetComponent<BulletMove>().damage = towerData.tower_Damage;
    }

    private void Update()
    {
        GameObject target_enemy = null;

        float minDist = float.MaxValue;
        foreach(GameObject enemy in visible_Enemies)
        {
            float distance = enemy.GetComponent<Movement>().GetDistance();
            if(distance< minDist)
            {
                target_enemy = enemy;
                minDist = distance;
            }
        }

        if(target_enemy != null)
        {
            if(Time.time - lastShoot > towerData.shoot_Interval)
            {
                Shoot(target_enemy.GetComponent<Collider2D>());
                lastShoot = Time.time;

            }


        }
    }

    //убираем врага из массива visible_Enemies
    void RemoveEnemy(GameObject enemy)
    {
        visible_Enemies.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            visible_Enemies.Add(collision.gameObject);
            DamageEnemy enemyTakeDamage_delegate = collision.gameObject.GetComponent<DamageEnemy>();
            enemyTakeDamage_delegate.enemyTakeDamage += RemoveEnemy;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            visible_Enemies.Remove(collision.gameObject);
            DamageEnemy enemyTakeDamage_delegate = collision.gameObject.GetComponent<DamageEnemy>();
            enemyTakeDamage_delegate.enemyTakeDamage -= RemoveEnemy;
        }
    }

    void Shoot(Collider2D enemy)
    {
        Vector3 startPos = startPosition.position;
        Vector3 enemyPos = enemy.transform.position;

        GameObject instBullet = (GameObject)Instantiate(bullet,startPos,Quaternion.identity);


        BulletMove bulletMove = instBullet.GetComponent<BulletMove>();
        bulletMove.startPosition = startPos;
        bulletMove.finishPosition = enemyPos;
        bulletMove.goal = enemy.gameObject;



    }
    
    public int getTowerSalePrice()
    {
        return towerData.sell_Price;
    }

    public int getTowerBuildPrice()
    {
        return towerData.build_Price;
    }
}
