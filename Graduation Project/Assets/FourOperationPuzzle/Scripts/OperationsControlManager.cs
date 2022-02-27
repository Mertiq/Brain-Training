using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace FourOperations {

   
    [System.Serializable]
    public struct OperationMap {
        public OperationIndex OperationIndex;
        public Operation operation;

    }
    public class OperationsControlManager : MonoBehaviour {
        public OperationMap[] operations = new OperationMap[4];
        public DraggableOperand[] draggableOperands = new DraggableOperand[3];
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
             for(int i = 0; i < guessableOperands.Count; i++) {
                draggableOperands[i].SetValue(guessableOperands[i]);
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
                    Debug.Log("You win!");
                }else{
                    Debug.Log("You lost!");
                }
            }
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