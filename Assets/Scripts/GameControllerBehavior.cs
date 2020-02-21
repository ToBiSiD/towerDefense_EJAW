using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour
{
    public TMP_Text waveCount_label;
    public GameObject newWave_label;

    public TMP_Text health_label;
    public TMP_Text gold_label;

    private int player_health_count;

    public int Player_health_count
    {
        get { return player_health_count;}
        set
        {
            player_health_count = value;
            health_label.text =  player_health_count.ToString();
            if(player_health_count<= 0 && !lose)
            {
                lose = true;
            }
        }
    }

    public bool lose = false;

    private int gold;
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            gold_label.text = gold.ToString();
        }
    }

    private int wave;
    public int Wave
    {
        get { return wave; }
        set { wave = value; }         
    }

    private int max_count_wave;
    public int Max_count_Wave
    {
        get { return max_count_wave; }
        set { max_count_wave = value; }
    }

    void Start()
    {
        Player_health_count = 20;
        Gold = 50;
        Wave = 0;
        newWave_label.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        waveCount_label.text = "<b>Wave:</b> " + wave  + "/" + max_count_wave;
    }
}
