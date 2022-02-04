using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject grid;
   
  public void onExitPressed()
    {
        grid.SetActive(false);
     
    }
}
