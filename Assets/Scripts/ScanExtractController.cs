using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanExtractController : MonoBehaviour
{

    public Toggle scanExtractToggle;
    public int NumberOfScans;
    public int MaxNumberOfScans = 6;
    public bool scanMode;
    public bool ReachedMaxOfScans;
    void Start()
    {
        ReachedMaxOfScans = false;
        NumberOfScans = 0;
        scanMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scanExtractToggle.isOn)
        {
                scanMode = true;
          
        }
        else
            scanMode = false;
    }
    public void NumberOfScansCounter()
    {
        if (NumberOfScans < MaxNumberOfScans)
        {
           
            NumberOfScans++;
        }
        else
            ReachedMaxOfScans = true;
    }
}