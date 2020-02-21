using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    public GameObject[] road_points;
    private int current_road_point = 0;
    private float switchTimeFromLastPoint;
    private float speed;

    void Start()
    {
        speed = enemyData.Move_speed;
        switchTimeFromLastPoint = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = road_points[current_road_point].transform.position;
        Vector3 nextPos = road_points[current_road_point + 1].transform.position;


        //get parametrs needed to come on next point 
        float path_time = Vector3.Distance(startPos, nextPos) / speed;
        float current_time = Time.time - switchTimeFromLastPoint;
        gameObject.transform.position = Vector2.Lerp(startPos, nextPos, current_time / path_time);


        if (gameObject.transform.position.Equals(nextPos))
        {
            if (current_road_point < road_points.Length - 2)
            {
               
                current_road_point++;
                switchTimeFromLastPoint = Time.time;
              
            }
            else
            {
                Destroy(gameObject);
                GameControllerBehavior gameController = GameObject.Find("GameController").GetComponent<GameControllerBehavior>();
                gameController.Player_health_count -= enemyData.enemy_Damage;
            }
        }
    }

    public float GetDistance()
    {
        float distance = 0;
        distance += Vector2.Distance(transform.position,
            road_points[current_road_point].transform.position);
        for(int i = current_road_point+1;i< road_points.Length - 1; i++)
        {
            Vector3 firstPos = road_points[i].transform.position;
            Vector3 secPos = road_points[i + 1].transform.position;
            distance += Vector2.Distance(firstPos, secPos);
        }
        return distance;
    }
}

