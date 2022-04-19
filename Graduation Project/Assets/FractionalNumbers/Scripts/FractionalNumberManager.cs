using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FractionalNumbers { 
    public class FractionalNumberManager : MonoBehaviour
    {
        public GameObject filledItem;
        public GameObject emptyItem;
        public GameObject content;

        public EventSystem eventSystem;
        private Answer selectedAnswer;

        public int minDenominator;
        public int maxDenominator;

        private int interest;
        private int denominator;

        public Answer[] answers = new Answer[4];

        void Awake()
        {
            PrepareAnswers();
        }
        public void PrepareAnswers()
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
            answers[randomIndexes.Pop()].SetFractionals(interest, denominator);
            //
            
            int answer1denominator =  Random.Range(minDenominator, maxDenominator);
            int answer1interest = Random.Range(1, denominator);
            if(answer1denominator == denominator && answer1interest == interest)
            {
                answer1denominator++;
                answer1interest++;
            }
            answers[randomIndexes.Pop()].SetFractionals(answer1interest, answer1denominator);

            int answer2denominator = Random.Range(minDenominator, maxDenominator);
            int answer2interest = Random.Range(1, denominator);

            if(answer2denominator == denominator ||answer2denominator == answer1denominator)
            {
                answer2denominator = answer2denominator -= 2;   
            }
            answers[randomIndexes.Pop()].SetFractionals(answer2interest, answer2denominator);

            int answer3denominator = Random.Range(minDenominator, maxDenominator);
            int answer3interest = Random.Range(1, denominator);

            if(answer3denominator == denominator || answer3denominator == answer2denominator || answer3denominator == answer1denominator)
            {
                int random = Random.Range(-2, 7);
                answer3denominator = answer3denominator + random;
            }

            answers[randomIndexes.Pop()].SetFractionals(answer3interest, answer3denominator);
        }
        public Stack<int> PrepareForRandomArrayIndexes()
        {
            Stack<int> s = new Stack<int>();
            int number1 = Random.Range(0, answers.Length);
            s.Push(number1);
            int number2 = Random.Range(0, answers.Length); ;
            if(number2 == number1 && number2 <=0)
            {
                number2++;
            }else if (number2 == number1 && number2 >=3)
            {
                number2--;
            }
            s.Push(number2);
            for(int i =0; i < answers.Length; i++)
            {
                if(!s.Contains(i))
                {
                    s.Push(i);
                }
            }
            return s;
        }
        public void Submit()
        {
            if (IsGivenAnswerCorrect())
            {
                Debug.Log("You're done");
            }else
            {
                Debug.Log("You're wrong");
            }
           
        }
        public void ChooseAnswer(Answer answer)
        {
            selectedAnswer = answer;
        }
        public bool IsGivenAnswerCorrect()
        {
            int selectedInterest = selectedAnswer.GetInterest();
            int selectedDenominator = selectedAnswer.GetDenominator();
            return (selectedInterest == interest && selectedDenominator == denominator);
        }
    }
}
