using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    public int damage;
    public GameObject goal;
    public Vector3 startPosition;
    public Vector3 finishPosition;

    public int minGold;
    public int maxGold;

    private float distance;
    private float time;

    private GameControllerBehavior gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerBehavior>();
        distance = Vector2.Distance(startPosition, finishPosition);
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float interval = Time.time - time;
        transform.position = Vector3.Lerp(startPosition, finishPosition, interval * speed / distance);
        
        if (transform.position.Equals(finishPosition))
        {
            if(goal != null)
            {
                
                Enemy_healthBar enemyHp = goal.GetComponent<Enemy_healthBar>();
                enemyHp.Current_health -= damage;
                

                if (enemyHp.Current_health <= 0)
                {
                    Destroy(goal);
                    gameController.Gold += Random.Range(minGold,maxGold);
                }

            }
            Destroy(gameObject);
        }
    }
}
