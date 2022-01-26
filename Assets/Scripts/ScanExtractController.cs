using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanExtractController : MonoBehaviour
{

    public Toggle scanExtractToggle;
    public int NumberOfScans;
    public int MaxNumberOfScans = 6;
    public int numberOfExtractions;
    public int MaxNumberOfExtractions = 3;
    public bool scanMode, extractMode;
    public bool ReachedMaxOfScans;
    public bool ReachedMaxOfExtracts;
    private int score;
    
    
    public GameObject result,UpdateMsg,scoreLabel;
    void Start()
    {
        

        score = 0;
        ReachedMaxOfScans = false;
        ReachedMaxOfExtracts = false;
        numberOfExtractions = 1;
        extractMode = false;
        NumberOfScans = 1;
        scanMode = false;
       
    }

    
    void Update()
    {
       
        if (scanExtractToggle.isOn)
        {
            scanMode = true;
            extractMode = false;

        }
        else
        {
            scanMode = false;
          
            extractMode = true;
        }
        if(ReachedMaxOfExtracts)
            result.GetComponent<TMPro.TextMeshProUGUI>().text = ("The amount of collected resources: "+ score);
    }
  
    public void NumberOfScansCounter()
    {
        if (NumberOfScans < MaxNumberOfScans)
        {

            NumberOfScans++;
        }
        else
        {
           
            ReachedMaxOfScans = true;
           
        }
    }
    public void NumberOfExtractionsCounter()
    {
        if (numberOfExtractions < MaxNumberOfExtractions)
        {

            numberOfExtractions++;
          

        }
        else
            ReachedMaxOfExtracts = true;
    }
    public void UpdateMsgOnScreen(Resources value)
    {
        UpdateMsg.GetComponent<TMPro.TextMeshProUGUI>().text = ("You extracted " + value.ToString());
    }
    public void scoreCalculator(Resources value)
    {
        switch (value)
        {
            case Resources.MAX:
                score += 100;
                break;
            case Resources.HALF:
                score += 50;
                break;
            case Resources.QUARTER:
                score += 25;
                break;
            case Resources.EMPTY:
                score += 0;
                break;
        }
        scoreLabel.GetComponent<TMPro.TextMeshProUGUI>().text = (score.ToString());

    }
}