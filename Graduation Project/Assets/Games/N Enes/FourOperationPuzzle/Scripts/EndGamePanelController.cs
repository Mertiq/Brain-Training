using UnityEngine;
using UnityEngine.UI;
namespace FourOperations {
    public class EndGamePanelController : MonoBehaviour {
        
        public Text endGameText;

        public void SetEndGameText(string text) {
            this.endGameText.text = text;
        }
    }
}

