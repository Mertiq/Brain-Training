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
            if (isWrongReflect)
                gm.RightSelected();
            else
                gm.WrongSelected();
        }

        public void SetIsWrongReflect(bool isWrongReflect)
        {
            this.isWrongReflect = isWrongReflect;
        }
    }
}