using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionPuzzle
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int rows = 3;
        [SerializeField] private int cols = 3;
        [SerializeField] private float tileSize = 1;

        [SerializeField] private float placementRateHorizontal;
        [SerializeField] private float placementRateVertical;

        [SerializeField] private GameObject gridHolderReal;
        [SerializeField] private GameObject gridHolderReflection;

        void Start()
        {
            CreateGridHolders();
        }

        void Update()
        {

        }

        private void CreateGridHolders()
        {
            gridHolderReal.GetComponent<GridManager>().CreateGridHolder(rows, cols, tileSize, placementRateHorizontal, placementRateVertical);
            gridHolderReflection.GetComponent<GridManager>().CreateGridHolder(rows, cols, tileSize, 0.9f - placementRateHorizontal, placementRateVertical);
        }

        private void PlaceShapes()
        {

        }
    }
}