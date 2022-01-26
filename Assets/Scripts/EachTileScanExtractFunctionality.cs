using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EachTileScanExtractFunctionality : MonoBehaviour
{
    GameObject generatedTiles;
    public Color HiddenColor, MaxColor, HalfColor, QuarterColor, EmptyColor;
    public int score;
    private bool extracted;
    public int tileIndex = 0;
    Resources tileValue;
   
    void Start()
    {
      
        extracted = false;
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
     
        if (generatedTiles.GetComponent<ScanExtractController>().extractMode)
        {
            if (!extracted)
            {

                gameObject.GetComponent<Image>().color = Color.cyan;
            }
            else
            {
                gameObject.GetComponent<Image>().color = HalfColor;
            }
           
        }



    }

    public void OnMouseDown()
    {

        if (generatedTiles.GetComponent<ScanExtractController>().scanMode && !generatedTiles.GetComponent<ScanExtractController>().ReachedMaxOfScans)
        {
            ScanTiles();

        }
        else if (generatedTiles.GetComponent<ScanExtractController>().extractMode && !generatedTiles.GetComponent<ScanExtractController>().ReachedMaxOfExtracts)
        {
            ExtractTiles();
        }

    }
    private void ExtractTiles()
    {
        int index = 0;

        generatedTiles.GetComponent<ScanExtractController>().NumberOfExtractionsCounter();
        while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
        {
            if (generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.transform == this.transform)
            {
                tileValue = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].resourceValue;
                generatedTiles.GetComponent<ScanExtractController>().UpdateMsgOnScreen(tileValue);
                extracted = true;
               
                int SelectedTileRow = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x;
                int SelectedTileColumn = generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y;
                setTileColors(SelectedTileRow, SelectedTileColumn);
                generatedTiles.GetComponent<ScanExtractController>().scoreCalculator(generatedTiles.GetComponent<TileGeneration>().tilesArray[index].resourceValue);
                adjustNeighboursValues(SelectedTileRow,SelectedTileColumn);
                generatedTiles.GetComponent<TileGeneration>().tilesArray[index].resourceValue = Resources.EXTRACTED;
                generatedTiles.GetComponent<TileGeneration>().tilesArray[index].tileGameObject.gameObject.GetComponent<Button>().interactable = false;

                

             


            }
            index++;
        }
    }
    private void adjustNeighboursValues(int row, int column)
    {
   
        int RowBeforeMax = row - 1;
        int ColumnBeforeMax = column - 1;
        int RowAfterMax = row + 1;
        int ColumnAfterMax = column + 1;
        int TwoRowsBeforeMax = row - 2;
        int TwoRowsAfterMax = row + 2;
        int TwoColumnsBeforeMax = column - 2;
        int TwoColumnsAfterMax = column + 2;
        for (int i = 0; i < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count; i++)
        {
           

                if ((generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == column) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == row && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == row && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == column) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == TwoRowsAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == TwoColumnsAfterMax)||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == column) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowBeforeMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnAfterMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnBeforeMax) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y ==column) ||
                   (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == RowAfterMax && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnAfterMax) ||
                    (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == row && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnAfterMax) ||
                      (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].x == row && generatedTiles.GetComponent<TileGeneration>().tilesArray[i].y == ColumnBeforeMax))
                {
                switch (generatedTiles.GetComponent<TileGeneration>().tilesArray[i].resourceValue)
                {
                    case Resources.MAX:
                        generatedTiles.GetComponent<TileGeneration>().tilesArray[i].resourceValue = Resources.HALF;
                   
                        break;
                    case Resources.HALF:
                        generatedTiles.GetComponent<TileGeneration>().tilesArray[i].resourceValue = Resources.QUARTER;
                      
                        break;
                    case Resources.QUARTER:
                        generatedTiles.GetComponent<TileGeneration>().tilesArray[i].resourceValue = Resources.EMPTY;
                     
                        break;
                    case Resources.EMPTY:
                        generatedTiles.GetComponent<TileGeneration>().tilesArray[i].resourceValue = Resources.EMPTY;
                      
                        break;
                }
            }
        }
       


    }

    private void ScanTiles()
    {
        int index = 0;
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
        private void setTileColors(int row, int column)
        {
            int index = 0;
            while (index < generatedTiles.GetComponent<TileGeneration>().tilesArray.Count)
            {

                if (generatedTiles.GetComponent<TileGeneration>().tilesArray[index].x == row && generatedTiles.GetComponent<TileGeneration>().tilesArray[index].y == column)
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


  