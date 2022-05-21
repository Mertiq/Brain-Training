using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FractionalNumbers
{
    [RequireComponent(typeof(Button))]
    public class Answer : MonoBehaviour
    {

        private int interest;
        private int denominator;
        public Text interestText;
        public Text denominatorText;
        
        

        public void SetFractionals(int interest, int denominator)
        {
            this.interest = interest;
            this.denominator = denominator;
            UpdateGUI();
        }
        public void UpdateGUI()
        {
            this.interestText.text = this.interest + "";
            this.denominatorText.text = this.denominator + "";
        }
        public void SetInterest(int interest)
        {
            this.interest = interest;
        }
        public void SetDenominator(int denominator)
        {
            this.denominator = denominator;
        }
        public int GetInterest()
        {
            return this.interest;
        }
        public int GetDenominator()
        {
            return this.denominator;
        }
    }
}