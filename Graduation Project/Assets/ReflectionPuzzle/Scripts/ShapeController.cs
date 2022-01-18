using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReflectionPuzzle
{
    public class ShapeController : MonoBehaviour
    {
        private GameManager gm;
        private bool isWrongReflect = false;

        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        public void UserSelectShape()
        {
            Debug.Log("alo");
            if (isWrongReflect)
                gm.NextLevel();
            else
                gm.WrongSelected();
        }

        public void SetIsWrongReflect(bool isWrongReflect)
        {
            this.isWrongReflect = isWrongReflect;
        }
    }
}