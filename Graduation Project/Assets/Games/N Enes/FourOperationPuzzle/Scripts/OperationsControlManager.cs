using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


namespace FourOperations {

   
    [System.Serializable]
    public struct OperationMap {
        public OperationIndex OperationIndex;
        public Operation operation;

    }
    public class OperationsControlManager : MonoBehaviour {
        public OperationMap[] operations = new OperationMap[4];
        public DraggableOperand[] draggableOperands = new DraggableOperand[3];
        public AudioManager audioManager;
        public GameObject endGamePanel;
        public Text endGameCurrentScoreText;
        public void InitalizeOperations() {
            Operation firstOp = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
            Operation secondOp = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);
            Operation thirdOp = GetOperation(OperationIndex.LEFT_TOP_TO_BOTTOM);
            Operation fourthOp = GetOperation(OperationIndex.RIGHT_TOP_TO_BOTTOM);
            Operations.InitializeCompleteOperation(firstOp);
            Operations.InitializeCompleteOperation(secondOp);
            Operations.CompleteHalfCompletedOperation(OperationIndex.LEFT_TOP_TO_BOTTOM,thirdOp);
            Operations.CompleteHalfCompletedOperation(OperationIndex.RIGHT_TOP_TO_BOTTOM,fourthOp);

            Operand hintOperand = RandomlyChooseAnOperandToHint();
            hintOperand.SetGuessedOperand(hintOperand.GetOperand());
            hintOperand.SetIsHint(true);
            RegisterOperandEvents();
            InitializeDraggableOperandValues();

        }
        void Awake() {
            InitalizeOperations();
            
        }
        private void Start()
        {
            StartBackgroundMusic();
        }

        public void StartBackgroundMusic()
        {
            audioManager.PlaySound("background");
        }
        public Operation GetOperation(OperationIndex opIndex) {
            for(int i = 0; i < operations.Length; i++) {
                if (operations[i].OperationIndex == opIndex) {
                    return operations[i].operation;
                }
            }
            return new Operation();
        }
        public Operand RandomlyChooseAnOperandToHint(){
            Operand[] possibleOperands = GetPossibleOperandsToShowAsHint();
            return possibleOperands[MathOps.rd.Next(0,possibleOperands.Length)];
        }
        public List<int> GuessableOperands() {
            List<int> guessableOperands = new List<int>();
            Operation first = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
            Operation fourth = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);
            if(!first.LeftOperand.GetIsHint()){
                guessableOperands.Add(first.LeftOperand.GetOperand());
            }
            if(!first.RightOperand.GetIsHint()){
                guessableOperands.Add(first.RightOperand.GetOperand());
            }
            if(!fourth.LeftOperand.GetIsHint()){
                guessableOperands.Add(fourth.LeftOperand.GetOperand());
            }
            if(!fourth.RightOperand.GetIsHint()){
                guessableOperands.Add(fourth.RightOperand.GetOperand());
            }
            return guessableOperands;
        }
        public void InitializeDraggableOperandValues(){
            List<int> guessableOperands = GuessableOperands();
            Shuffle(guessableOperands);
             for(int i = 0; i < guessableOperands.Count; i++) {
                draggableOperands[i].SetValue(guessableOperands[i]);
            }
        }
        private static System.Random rng = new System.Random();

        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public bool IsGameFinished() {
            Operation firstOperation = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
            Operation fourthOperation = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);

            Operand first = firstOperation.LeftOperand;
            Operand second = firstOperation.RightOperand;
            Operand third = fourthOperation.LeftOperand;
            Operand fourth = fourthOperation.RightOperand;

            if(first.GetIsGuessed() && second.GetIsGuessed() && third.GetIsGuessed() && fourth.GetIsGuessed() ){
                return true;
            }
            return false;
        }

        public void ControlEndGame() {
            if(IsGameFinished()){
                Operation firstOperation = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
                Operation fourthOperation = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);

                Operand first = firstOperation.LeftOperand;
                Operand second = firstOperation.RightOperand;
                Operand third = fourthOperation.LeftOperand;
                Operand fourth = fourthOperation.RightOperand;

                if(first.GetIsCorrectlyGuessed() && second.GetIsCorrectlyGuessed() && third.GetIsCorrectlyGuessed() && fourth.GetIsCorrectlyGuessed() ){
                    audioManager.StopSound("background");
                    audioManager.PlaySound("win-music");
                    float score = SkillSystemManager.Multiplier[SkillSystemManager.GameName.FourOp];
                    SkillSystemManager.CalculateSkillPoint(MainMenu.Category.Arithmetic, SkillSystemManager.GameName.FourOp, score);
                    endGameCurrentScoreText.text = score + "";
                    endGamePanel.SetActive(true);
                    MainMenuAnimationController.VeryVeryShake(endGamePanel);
                    Time.timeScale = 0f;
                   
                }
            }
        }
        public void RestartGame()
        {
            SceneManager.LoadScene("Four Operation Puzzle");
        }
        public void ClearGameArtifacts()
        {
            Operation firstOp = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
            Operation secondOp = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);
            Operation thirdOp = GetOperation(OperationIndex.LEFT_TOP_TO_BOTTOM);
            Operation fourthOp = GetOperation(OperationIndex.RIGHT_TOP_TO_BOTTOM);

            firstOp.LeftOperand.ClearOperandValues();
            firstOp.RightOperand.ClearOperandValues();
            firstOp.Operator.SetOperator(Operators.NONE);

            secondOp.LeftOperand.ClearOperandValues();
            secondOp.RightOperand.ClearOperandValues();
            secondOp.Operator.SetOperator(Operators.NONE);

            thirdOp.Operator.SetOperator(Operators.NONE);
            thirdOp.LeftOperand.ClearOperandValues();
            thirdOp.RightOperand.ClearOperandValues();

            fourthOp.LeftOperand.ClearOperandValues();
            fourthOp.RightOperand.ClearOperandValues();
            fourthOp.Operator.SetOperator(Operators.NONE);
        }
        public void RegisterOperandEvents() {
                Operation firstOperation = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT);
                Operation fourthOperation = GetOperation(OperationIndex.BOTTOM_TO_RIGHT);

                Operand first = firstOperation.LeftOperand;
                Operand second = firstOperation.RightOperand;
                Operand third = fourthOperation.LeftOperand;
                Operand fourth = fourthOperation.RightOperand;

                first.AddOnDropListener(ControlEndGame);
                second.AddOnDropListener(ControlEndGame);
                third.AddOnDropListener(ControlEndGame);
                fourth.AddOnDropListener(ControlEndGame);
        }
                
        public Operand[] GetPossibleOperandsToShowAsHint(){
            Operand[] possibleOperands = new Operand[4];
            possibleOperands[0] = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT).LeftOperand;
            possibleOperands[1] = GetOperation(OperationIndex.LEFT_TOP_TO_RIGHT).RightOperand;
            possibleOperands[2] = GetOperation(OperationIndex.BOTTOM_TO_RIGHT).LeftOperand;
            possibleOperands[3] = GetOperation(OperationIndex.BOTTOM_TO_RIGHT).RightOperand;
            return possibleOperands;
        }
    }
}