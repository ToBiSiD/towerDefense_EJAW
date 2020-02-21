using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUiBehavoir : MonoBehaviour
{
    public GameObject slot;

    public GameControllerBehavior gameControllerBehavior;
    

    private int price;


    private void Start()
    {
        gameControllerBehavior = GameObject.Find("GameController").GetComponent<GameControllerBehavior>();
        
    }

    private void OnEnable()
    {
        StartCoroutine(Close());
    }

    public void OnButtonUp(GameObject tower)
    {
        price = tower.GetComponent<SpawnBullet>().getTowerBuildPrice();

        if (gameControllerBehavior.Gold >= price)
        {
            Instantiate(tower, new Vector3(slot.transform.position.x,slot.transform.position.y + 0.55f, slot.transform.position.z), Quaternion.identity);
            gameControllerBehavior.Gold -= price;
            slot.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
