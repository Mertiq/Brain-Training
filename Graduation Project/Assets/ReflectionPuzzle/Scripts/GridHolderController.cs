using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReflectionPuzzle
{
    public class GridHolderController : MonoBehaviour
    {
        private GameObject tile;
        private GameObject shape;
        private GameObject[] tiles;
        private int cellSize;
        private List<GameObject> instantiatedShapes;
   
        private void Awake()
        {
            tile = Resources.Load("ReflectionPuzzle/Tile") as GameObject;
            shape = Resources.Load("ReflectionPuzzle/Shape") as GameObject;
            RectTransform rt = transform.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(Screen.width / 3, rt.sizeDelta.y);
            instantiatedShapes = new List<GameObject>();
        }

        private void Start()
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }

        public void CreateTiles(int rows, int cols)
        {
            InitLayout(rows, cols);
            tiles = new GameObject[rows * cols];

            for (int i = 0; i < rows * cols; i++)
                tiles[i] = Instantiate(tile, transform);
        }

        private void InitLayout(int rows, int cols)
        {
            int biggerConstrait = Mathf.Max(rows, cols);
            cellSize = Screen.width / biggerConstrait / 2;
            GetComponent<GridLayoutGroup>().constraintCount = rows;
            GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellSize, cellSize);

            if(transform.name == "RealTiles")
                GetComponent<GridLayoutGroup>().padding = new RectOffset(Mathf.RoundToInt(cellSize + cellSize / 3), 0, 0, 0);
            else
                GetComponent<GridLayoutGroup>().padding = new RectOffset(0, Mathf.RoundToInt(cellSize + cellSize / 3), 0, 0);
        }

        public void CreateShape(int tileIndex, Sprite shapeSprite, bool isReflectedShape)
        {
            GameObject s = Instantiate(shape, tiles[tileIndex].transform);
            s.GetComponent<Image>().sprite = shapeSprite;

            if(!isReflectedShape)
                s.GetComponent<Button>().enabled = false;

            instantiatedShapes.Add(s);
        }

        public void CreateWrongShape(int tileIndex, Sprite shapeSprite)
        {
            GameObject s = Instantiate(shape, tiles[tileIndex].transform);
            s.GetComponent<Image>().sprite = shapeSprite;
            s.GetComponent<ShapeController>().SetIsWrongReflect(true);
            instantiatedShapes.Add(s);
        }

        public void DestroyInstantiatedShapes()
        {
            foreach(GameObject shape in instantiatedShapes)
                Destroy(shape.gameObject);

            instantiatedShapes.Clear();
        }

        public void DisableButtons()
        {
            foreach (GameObject g in instantiatedShapes)
                g.GetComponent<Button>().enabled = false;
        }

        public void EnableButtons()
        {
            foreach (GameObject g in instantiatedShapes)
                g.GetComponent<Button>().enabled = true;
        }
    }
}
