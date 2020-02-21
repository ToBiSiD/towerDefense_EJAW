using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaleUIBehavior : MonoBehaviour
{
    public GameObject tower;
    private void Start()
    {

        GetComponentInChildren<TMP_Text>().text = tower.GetComponent<SpawnBullet>().getTowerSalePrice().ToString();
    }
    public void OnButtonUp(GameObject slot)
    {
        GameControllerBehavior gameControllerBehavior = GameObject.Find("GameController").GetComponent<GameControllerBehavior>();
        gameControllerBehavior.Gold += tower.GetComponent<SpawnBullet>().getTowerSalePrice();
        Instantiate(slot, new Vector3(tower.transform.position.x, tower.transform.position.y - 0.55f, tower.transform.position.z), Quaternion.identity);

        Destroy(tower);
        Destroy(gameObject);
    }
}
