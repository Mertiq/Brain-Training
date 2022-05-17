using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GuessPercentage
{
        [RequireComponent(typeof(Button))]
        public class PercentageAnswer : MonoBehaviour
        {
            [Header("Health Settings")]
            private int interest;
            private int denominator;
            public Text percentageText;
            

            public void SetFractionals(int interest, int denominator)
            {
                this.interest = interest;
                this.denominator = denominator;
                UpdateGUI();
            }
            public void UpdateGUI()
            {
                this.percentageText.text = ((float)((float)this.interest / (float)this.denominator) * 100 ).ToString("0.0");
                //float number = ((float)((float)this.interest / (float)this.denominator) * 100);
                //number % 1 == 0 ise tam 

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