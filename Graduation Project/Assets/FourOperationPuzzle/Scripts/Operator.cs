using System;
using UnityEngine;
using UnityEngine.UI;

namespace FourOperations{
    public class Operator : MonoBehaviour {
        public Text operatorText;
        private Operators _operator;

        public Operators GetOperator() {
            return this._operator;
        }
        public void SetOperator(Operators opNum) {
            this._operator = opNum;
            operatorText.text = Operations.GetOperationStr(this._operator);
        }

    }
}