using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
   
    public GameObject tower_build_ui;

 
    private void OnMouseUp()
    {
        tower_build_ui.SetActive(true);
        tower_build_ui.GetComponent<BuildUiBehavoir>().slot = gameObject;
    }

 

}
