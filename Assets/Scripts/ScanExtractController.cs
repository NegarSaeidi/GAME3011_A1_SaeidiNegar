using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanExtractController : MonoBehaviour
{

    public Toggle scanExtractToggle;

    public bool scanMode;
    void Start()
    {
        scanMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scanExtractToggle.isOn)
            scanMode = true;
        else
            scanMode = false;
    }
}
