using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMiniGame : MonoBehaviour
{
    [SerializeField]
    GameObject startPanel;

    [SerializeField]
    GameObject miniGamePanel;
   

    public void onStartButtonPressed()
    {
        startPanel.SetActive(false);
        miniGamePanel.SetActive(true);

    }
}
