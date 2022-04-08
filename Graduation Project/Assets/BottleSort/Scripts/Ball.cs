using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utilities;

namespace BottleSort {
  
    public class Ball : MonoBehaviour {
        public Color color;
 
        private void Awake() {
            gameObject.GetComponent<Image>().color = new Vector4(color.r,color.g,color.b,color.a);
        }
    }
}