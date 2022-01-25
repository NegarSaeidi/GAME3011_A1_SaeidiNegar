using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGeneration : MonoBehaviour
{
    private GameObject[] tiles;
    public List<Tile> tilesArray;
    [SerializeField]
    private GameObject tilePrefab;

    public GameObject gridPanel;
    private bool tileGenerated;
    public int GridSize;

    private void Start()
    {
        tilesArray = new List<Tile>();

        tileGenerated = false;
    }
    private void Update()
    {
        if (this.gameObject.active && !tileGenerated)
        {
            tileGenerated = true;
            generateTiles(GridSize);
            ResourceAssignment();

        }
    }
    private void generateTiles(int size)
    {
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newTile.gameObject.transform.SetParent(gridPanel.gameObject.transform);

                tilesArray.Add(new Tile { x = i, y = j, tileGameObject = newTile, resourceValue = Resources.NOTASSIGNED });



            }




        }
    }
    private void ResourceAssignment()
    {
        int index = 0;
        while (index < tilesArray.Count)
        {

            if (tilesArray[index].resourceValue == Resources.NOTASSIGNED)
            {
                int randX = Random.Range(3, 30);
                int randY = Random.Range(3, 30);
                if (tilesArray[index].x % randX == 0 && tilesArray[index].y % randY == 0)
                {
                    tilesArray[index].resourceValue = Resources.MAX;
                    tilesArray[index].tileGameObject.gameObject.GetComponent<Image>().color = Color.red;
                    HalfTilesGeneration(index);
                    QuarterTilesGeneration(index);
                    EmptyTilesGeneration(index);
                }
            }
            index++;

        }
    }
    private void HalfTilesGeneration(int index)
    {
        
            //Half Tiles
            int MaxTileRow = tilesArray[index].x;
            int MaxTileColumn = tilesArray[index].y;
            int RowBeforeMax = tilesArray[index].x - 1;
            int ColumnBeforeMax = tilesArray[index].y - 1;
            int RowAfterMax = tilesArray[index].x + 1;
            int ColumnAfterMax = tilesArray[index].y + 1;

            for(int i=0;  i<tilesArray.Count; i++)
            {
              if (tilesArray[i].resourceValue == Resources.NOTASSIGNED)
           
                if ((tilesArray[i].x ==RowBeforeMax && tilesArray[i].y == ColumnBeforeMax) ||
                   (tilesArray[i].x == RowBeforeMax && tilesArray[i].y == MaxTileColumn) ||
                   (tilesArray[i].x == RowBeforeMax && tilesArray[i].y == ColumnAfterMax)||
                   (tilesArray[i].x == RowAfterMax && tilesArray[i].y == ColumnBeforeMax) ||
                   (tilesArray[i].x == RowAfterMax && tilesArray[i].y == MaxTileColumn)||
                   (tilesArray[i].x == RowAfterMax && tilesArray[i].y == ColumnAfterMax) ||
                    (tilesArray[i].x == MaxTileRow && tilesArray[i].y == ColumnAfterMax) ||
                      (tilesArray[i].x == MaxTileRow && tilesArray[i].y == ColumnBeforeMax))
                {
                    tilesArray[i].resourceValue = Resources.HALF;
                    tilesArray[i].tileGameObject.gameObject.GetComponent<Image>().color = Color.blue;
                }
              
              
               
            }
        
    }
    private void QuarterTilesGeneration(int index)
    {
        //Quarter Tiles
        int MaxTileRow = tilesArray[index].x;
        int MaxTileColumn = tilesArray[index].y;
        int RowBeforeMax = tilesArray[index].x - 1;
        int ColumnBeforeMax = tilesArray[index].y - 1;
        int RowAfterMax = tilesArray[index].x + 1;
        int ColumnAfterMax = tilesArray[index].y + 1;
        int TwoRowsBeforeMax = tilesArray[index].x - 2;
        int TwoRowsAfterMax = tilesArray[index].x + 2;
        int TwoColumnsBeforeMax = tilesArray[index].y - 2;
        int TwoColumnsAfterMax = tilesArray[index].y + 2;

        for (int i = 0; i < tilesArray.Count; i++)
        {
            if (tilesArray[i].resourceValue == Resources.NOTASSIGNED)

                if ((tilesArray[i].x == TwoRowsBeforeMax && tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (tilesArray[i].x == TwoRowsBeforeMax && tilesArray[i].y == ColumnBeforeMax) ||
                   (tilesArray[i].x == TwoRowsBeforeMax && tilesArray[i].y == MaxTileColumn) ||
                   (tilesArray[i].x == TwoRowsBeforeMax && tilesArray[i].y == ColumnAfterMax) ||
                   (tilesArray[i].x == TwoRowsBeforeMax && tilesArray[i].y == TwoColumnsAfterMax) ||
                   (tilesArray[i].x == RowBeforeMax && tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (tilesArray[i].x == RowBeforeMax && tilesArray[i].y == TwoColumnsAfterMax) ||
                   (tilesArray[i].x == MaxTileRow && tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (tilesArray[i].x == MaxTileRow && tilesArray[i].y == TwoColumnsAfterMax) ||
                   (tilesArray[i].x == RowAfterMax && tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (tilesArray[i].x == RowAfterMax && tilesArray[i].y == TwoColumnsAfterMax) ||
                   (tilesArray[i].x == TwoRowsAfterMax && tilesArray[i].y == TwoColumnsBeforeMax) ||
                   (tilesArray[i].x == TwoRowsAfterMax && tilesArray[i].y == ColumnBeforeMax) ||
                   (tilesArray[i].x == TwoRowsAfterMax && tilesArray[i].y == MaxTileColumn) ||
                   (tilesArray[i].x == TwoRowsAfterMax && tilesArray[i].y == ColumnAfterMax) ||
                   (tilesArray[i].x == TwoRowsAfterMax && tilesArray[i].y == TwoColumnsAfterMax)  )
                {
                    tilesArray[i].resourceValue = Resources.HALF;
                    tilesArray[i].tileGameObject.gameObject.GetComponent<Image>().color = Color.yellow;
                }



        }
    }
    private void EmptyTilesGeneration(int index)
    {

    }
}