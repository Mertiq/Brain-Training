using System;
using UnityEngine;
using UnityEngine.UI;

namespace FourOperations{
    public class Result : MonoBehaviour {
        public Text resultText;
        private int result;
        public int GetResult(){
            return this.result;
        }
        public void SetResult(int result) {
            this.result = result;
            this.resultText.text = this.result+"";
        }
    }
}