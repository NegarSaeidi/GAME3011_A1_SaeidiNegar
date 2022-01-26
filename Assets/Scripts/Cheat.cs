using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public Color  MaxColor, HalfColor, QuarterColor, EmptyColor;
    GameObject generatedTiles;
    private bool isCheating;
    private void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        isCheating = false;
        foreach (GameObject go in allObjects)
        {

            if (go.name == "MiniGamePanel")
            {
                generatedTiles = go;
            }



        }
    }
    private void Update()
    {
 
    }
    public void showPattern()
    {
        isCheating = true;
        int index = 0;
        while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
        {
            switch (generatedTiles.GetComponent<TileGeneration>().tilesArray[index].resourceValue)
            {
                case Resources.MAX:
                    generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = MaxColor;
                    break;
                case Resources.HALF:
                    generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = HalfColor;
                    break;
                case Resources.QUARTER:
                    generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = QuarterColor;
                    break;
                case Resources.EMPTY:
                    generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = EmptyColor;
                    break;

            }
            index++;
        }
        StartCoroutine(cleanTiles());
    }
    IEnumerator cleanTiles()
    {
        yield return new WaitForSeconds(2.0f);

        int index = 0;
        while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
        {
           
                generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = Color.cyan;
            
            index++;
        }
    }
}
