using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionPuzzle
{

    public class GridManager : MonoBehaviour
    {
        private GameObject tile;
        private Vector3 gridHolderPos;

        private int rows;
        private int cols;
        private float tileSize;

        private void Awake()
        {
            tile = Resources.Load("ReflectionPuzzle/Tile") as GameObject; 
        }

        public void CreateGridHolder(int rows, int cols, float tileSize, float placementRateHorizontal, float placementRateVertical)
        {
            this.rows = rows;
            this.cols = cols;
            this.tileSize = tileSize;

            tile.transform.localScale = new Vector3(tileSize, tileSize);

            gridHolderPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * placementRateHorizontal, Screen.height * placementRateVertical, 10f));
            gridHolderPos.y += tileSize * rows / 2;
            InitializeGrid();
        }
        
        private void InitializeGrid()
        {
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    GameObject t = Instantiate(tile, transform);

                    float posX = col * tileSize;
                    float posY = row * -tileSize;

                    t.transform.position = new Vector3(posX, posY, 10f);
                }
            }

            transform.position = gridHolderPos;
        }
    }
}
