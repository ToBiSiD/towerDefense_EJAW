using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Towers/Standart Tower", fileName ="New Tower")]
public class TowerData : ScriptableObject
{

    [Tooltip("GameObject")]
    [SerializeField] private GameObject mainObject;
    public GameObject MainObject
    {
        get { return mainObject; }
        protected set { }
    }

    [Tooltip("Build price")]
    [SerializeField] private int build_price;
    public int build_Price
    {
        get { return build_price; }
        protected set { }
    }

    [Tooltip("Sell price")]
    [SerializeField] private int sell_price;
    public int sell_Price
    {
        get { return sell_price; }
        protected set { }
    }

    [Tooltip("Range")]
    [SerializeField] private float tower_range;
    public float tower_Range
    {
        get { return tower_range; }
        protected set { }
    }


    [Tooltip("Shoot interval")]
    [SerializeField] private float shoot_interval;
    public float shoot_Interval
    {
        get { return shoot_interval; }
        protected set { }
    }


    [Tooltip("Damage")]
    [SerializeField] private int tower_damage;
    public int tower_Damage
    {
        get { return tower_damage; }
        protected set { }
    }



}
