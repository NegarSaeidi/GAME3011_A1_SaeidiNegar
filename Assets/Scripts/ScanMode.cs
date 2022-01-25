using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScanMode : MonoBehaviour
{
    GameObject generatedTiles;
    public Color HiddenColor, MaxColor, HalfColor, QuarterColor, EmptyColor;

  
    void Start()
    {
       
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {

            if (go.name == "MiniGamePanel")
            {
                generatedTiles = go;
            }
        
           

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!generatedTiles.GetComponent<ScanExtractController>().scanMode)
            gameObject.GetComponent<Image>().color = Color.cyan;
             
            
        
    }

    public void OnMouseDown()
    {
        int index = 0;
        if (generatedTiles.GetComponent<ScanExtractController>().scanMode && !generatedTiles.GetComponent<ScanExtractController>().ReachedMaxOfScans)
        {
            generatedTiles.GetComponent<ScanExtractController>().NumberOfScansCounter();
            while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
            {
                if (generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.transform == this.transform)
                {
                    int SelectedTileRow = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x;
                    int SelectedTileColumn = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y;
                    int RowBeforeSelectedTile = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x - 1;
                    int ColumnBeforeSelectedTile = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y - 1;
                    int RowAfterSelectedTile = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x + 1;
                    int ColumnAfterSelectedTile = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y + 1;
                    setTileColors(RowBeforeSelectedTile, ColumnBeforeSelectedTile);
                    setTileColors(RowBeforeSelectedTile, SelectedTileColumn);
                    setTileColors(RowBeforeSelectedTile, ColumnAfterSelectedTile);
                    setTileColors(SelectedTileRow, ColumnBeforeSelectedTile);
                    setTileColors(SelectedTileRow, SelectedTileColumn);
                    setTileColors(SelectedTileRow, ColumnAfterSelectedTile);
                    setTileColors(RowAfterSelectedTile, ColumnBeforeSelectedTile);
                    setTileColors(RowAfterSelectedTile, SelectedTileColumn);
                    setTileColors(RowAfterSelectedTile, ColumnAfterSelectedTile);

                }
                index++;
            }
        }
       
    }
   
    private void setTileColors(int row, int column)
    {
        int index = 0;
        while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
        {

               if(generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x ==row && generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y==column)
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
               }


                index++;
        }
    
    }
}