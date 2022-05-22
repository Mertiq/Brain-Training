using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace GuessPercentage
{

    public class PercentageNumberManager : MonoBehaviour
    {
        public GameObject filledItem;
        public GameObject emptyItem;
        public GameObject content;

        public EventSystem eventSystem;
        private PercentageAnswer selectedPercentageAnswer;

        public int minDenominator;
        public int maxDenominator;

        private int interest;
        private int denominator;

        public PercentageAnswer[] PercentageAnswers = new PercentageAnswer[4];

        void Awake()
        {
            PreparePercentageAnswers();
        }
        public void PreparePercentageAnswers()
        {
            Stack<int> randomIndexes = PrepareForRandomArrayIndexes();
            denominator = Random.Range(minDenominator, maxDenominator);
            interest = Random.Range(1, denominator);
            for (int i = 0; i < interest; i++)
            {
                Instantiate(filledItem, content.transform);
            }
            for (int i = 0; i < denominator - interest; i++)
            {
                Instantiate(emptyItem, content.transform);
            }
            PercentageAnswers[randomIndexes.Pop()].SetFractionals(interest, denominator);
            //

            int PercentageAnswer1denominator = Random.Range(minDenominator, maxDenominator);
            int PercentageAnswer1interest = Random.Range(1, denominator);
            if (PercentageAnswer1denominator == denominator && PercentageAnswer1interest == interest)
            {
                PercentageAnswer1denominator++;
                PercentageAnswer1interest++;
            }
            PercentageAnswers[randomIndexes.Pop()].SetFractionals(PercentageAnswer1interest, PercentageAnswer1denominator);

            int PercentageAnswer2denominator = Random.Range(minDenominator, maxDenominator);
            int PercentageAnswer2interest = Random.Range(1, denominator);

            if (PercentageAnswer2denominator == denominator || PercentageAnswer2denominator == PercentageAnswer1denominator)
            {
                PercentageAnswer2denominator = PercentageAnswer2denominator -= 2;
            }
            PercentageAnswers[randomIndexes.Pop()].SetFractionals(PercentageAnswer2interest, PercentageAnswer2denominator);

            int PercentageAnswer3denominator = Random.Range(minDenominator, maxDenominator);
            int PercentageAnswer3interest = Random.Range(1, denominator);

            if (PercentageAnswer3denominator == denominator || PercentageAnswer3denominator == PercentageAnswer2denominator || PercentageAnswer3denominator == PercentageAnswer1denominator)
            {
                int random = Random.Range(-2, 7);
                PercentageAnswer3denominator = PercentageAnswer3denominator + random;
            }

            PercentageAnswers[randomIndexes.Pop()].SetFractionals(PercentageAnswer3interest, PercentageAnswer3denominator);
        }
        public Stack<int> PrepareForRandomArrayIndexes()
        {
            Stack<int> s = new Stack<int>();
            int number1 = Random.Range(0, PercentageAnswers.Length);
            s.Push(number1);
            int number2 = Random.Range(0, PercentageAnswers.Length); ;
            if (number2 == number1 && number2 <= 0)
            {
                number2++;
            }
            else if (number2 == number1 && number2 >= 3)
            {
                number2--;
            }
            s.Push(number2);
            for (int i = 0; i < PercentageAnswers.Length; i++)
            {
                if (!s.Contains(i))
                {
                    s.Push(i);
                }
            }
            return s;
        }
        public void Submit()
        {
            if (IsGivenPercentageAnswerCorrect())
            {
                Debug.Log("You're done");
            }
            else
            {
                Debug.Log("You're wrong");
            }

        }
        public void ChoosePercentageAnswer(PercentageAnswer PercentageAnswer)
        {
            selectedPercentageAnswer = PercentageAnswer;
        }
        public bool IsGivenPercentageAnswerCorrect()
        {
            int selectedInterest = selectedPercentageAnswer.GetInterest();
            int selectedDenominator = selectedPercentageAnswer.GetDenominator();
            return (selectedInterest == interest && selectedDenominator == denominator);
        }
    }
}
