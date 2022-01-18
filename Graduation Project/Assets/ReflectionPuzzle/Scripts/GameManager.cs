using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReflectionPuzzle
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int rows = 3;
        [SerializeField] private int cols = 3;

        [SerializeField] private GameObject gridHolderReal;
        [SerializeField] private GameObject gridHolderReflection;

        [SerializeField] private Sprite[] shapes;

        [SerializeField] private Text pointText;

        private GridHolderController ghcReal;
        private GridHolderController ghcReflected;

        private int placementShapeNumber = 0;
        private int[] randomTilesIndexes;
        private bool isWrongShapeSelected = false;

        private int point = 0;

        private void Awake()
        {
            placementShapeNumber = (rows * cols) / 2;
            ghcReal = gridHolderReal.GetComponent<GridHolderController>();
            ghcReflected = gridHolderReflection.GetComponent<GridHolderController>();
        }


        private void Start()
        {
            CreateGridHolders();
        }

        private void CreateGridHolders()
        {
            ghcReal.CreateTiles(rows, cols);
            ghcReflected.CreateTiles(rows, cols);
            PlaceShapes();
        }

        private void PlaceShapes()
        {
            randomTilesIndexes = new int[placementShapeNumber];
            int shapeCount = 0;
            
            for (int i = 0; i < placementShapeNumber; i++)
            {
                if (shapeCount == shapes.Length)
                    shapeCount = 0;

                randomTilesIndexes[i] = GetUniqueRandom();
                ghcReal.CreateShape(randomTilesIndexes[i], shapes[shapeCount++]);         
            }

            PlaceReflectedShapes();
        }

        private void PlaceReflectedShapes()
        {
            int shapeCount = 0;
            int index;

            for (int i = 0; i < placementShapeNumber; i++)
            {
                if (shapeCount == shapes.Length)
                    shapeCount = 0;

                if (isWrongShapeSelected)
                {
                    index = randomTilesIndexes[i];
                    ghcReflected.CreateShape(index, shapes[shapeCount++]);
                }
                else
                {
                    index = GetUniqueRandom();
                    isWrongShapeSelected = true;
                    ghcReflected.CreateShapeWrong(index, shapes[shapeCount++]);
                }
            }
        }      

        private int GetUniqueRandom()
        {
            int randomInt = Mathf.FloorToInt(Random.Range(0, rows * cols));
            bool isUnique = false;

            while (!isUnique)
            {
                if(CheckUniqueness(randomTilesIndexes, randomInt))
                    return randomInt;
                else
                    randomInt = Mathf.FloorToInt(Random.Range(0, rows * cols));
            }
       
            return 0;
        }

        private bool CheckUniqueness(int[] l, int number)
        {
            for (int i = 0; i < l.Length; i++)
                if (randomTilesIndexes[i] == number)
                    return false;

            return true;
        }

        public void NextLevel()
        {
            ghcReflected.DestroyInstantiatedShapes();
            ghcReal.DestroyInstantiatedShapes();

            isWrongShapeSelected = false;


            point += 10;
            pointText.text = point.ToString();

            PlaceShapes();
        }

        public void WrongSelected()
        {
            point -= 10;
            pointText.text = point.ToString();
        }
    }
}