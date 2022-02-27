using System;
using System.Collections.Generic;

namespace FourOperations {

    [System.Serializable]
    public struct Operation {
        public Operand LeftOperand;
        public Operator Operator;
        public Operand RightOperand;
        public Result Result;
    }
    public enum OperationIndex {
        LEFT_TOP_TO_RIGHT = 0,
        LEFT_TOP_TO_BOTTOM = 1,
        RIGHT_TOP_TO_BOTTOM = 2,
        BOTTOM_TO_RIGHT = 3
    }
    public enum Operators {
        MUL=0,
        ADD=1,
        SUBS=2,
        DIV =3
    }
    public static class Operations {
        public static string[] Ops = new string[4]{"x","+","-","/"};
        public static void MulAndSet(Operation op) {
            int leftOperandVal = MathOps.rd.Next(ResourceManager.mulMinOperand,ResourceManager.mulMaxOperand);
            int rightOperandVal = MathOps.rd.Next(ResourceManager.mulMinOperand,ResourceManager.mulMaxOperand);
            op.LeftOperand.SetOperand(leftOperandVal);
            op.RightOperand.SetOperand(rightOperandVal);
            op.Result.SetResult(leftOperandVal * rightOperandVal);
        }
        public static void AddAndSet(Operation op) {
            int leftOperandVal = MathOps.rd.Next(ResourceManager.addMinOperand,ResourceManager.addMaxOperand);
            int rightOperandVal = MathOps.rd.Next(ResourceManager.addMinOperand,ResourceManager.addMaxOperand);
            op.LeftOperand.SetOperand(leftOperandVal);
            op.RightOperand.SetOperand(rightOperandVal);
            op.Result.SetResult(leftOperandVal + rightOperandVal);
        }
        public static void SubsAndSet(Operation op) {
            int leftOperandVal = MathOps.rd.Next(ResourceManager.subsMinOperand,ResourceManager.subsMaxOperand);
            int rightOperandVal = MathOps.rd.Next(0,leftOperandVal);
            op.LeftOperand.SetOperand(leftOperandVal);
            op.RightOperand.SetOperand(rightOperandVal);
            op.Result.SetResult(leftOperandVal- rightOperandVal);
        }
        public static void DivAndSet(Operation op) {
            int leftOperandVal = MathOps.rd.Next(ResourceManager.divMinOperand,ResourceManager.divMaxOperand);
            List<int> subMultipliersOfLeftOperand = subMultipliers(leftOperandVal);
            int randIndex = MathOps.rd.Next(0,subMultipliersOfLeftOperand.Count);
            int rightOperandVal = subMultipliersOfLeftOperand[randIndex];
            op.LeftOperand.SetOperand(leftOperandVal);
            op.RightOperand.SetOperand(rightOperandVal);
            op.Result.SetResult(leftOperandVal / rightOperandVal);
        }
        public static List<int> subMultipliers(int number) {
            List<int> subMultiplerList = new List<int>();
            if(number == 0) {
                return null;
            }
            subMultiplerList.Add(1);
            int i = 2;
            while(i <= number) {
                if(number % i == 0){
                    subMultiplerList.Add(i); 
                } 
                i++;
            }
            return subMultiplerList;
        }
        public static string GetOperationStr(Operators operators) {
            return Ops[(int)operators];
        }
        
        public static List<Operators> PossibleOperations(Operation op) {
            int leftOperand = op.LeftOperand.GetOperand();
            int rightOperand = op.RightOperand.GetOperand();
            List<Operators> possibleOperations = new List<Operators>();
            
            if(MathOps.IsDivisible(leftOperand,rightOperand)){
                possibleOperations.Add(Operators.DIV);
            }
            if(MathOps.IsMultiplyable(leftOperand,rightOperand)){
                possibleOperations.Add(Operators.MUL);
            }
            if(MathOps.isAddable(leftOperand,rightOperand)){
                possibleOperations.Add(Operators.ADD);
            }
            if(MathOps.IsSubstractable(leftOperand,rightOperand)){
                possibleOperations.Add(Operators.SUBS);
            }
            //bugı çözmek için hiçbir işlem uymuyorsa toplama eklenir
            if(possibleOperations.Count == 0) {
                possibleOperations.Add(Operators.ADD);
            }
            return possibleOperations;
        }
        public static void InitializeCompleteOperation(Operation op) {
            Operators _operator = (Operators)MathOps.rd.Next(0,4);
            op.Operator.SetOperator(_operator);
            switch(_operator){
                case Operators.ADD:
                {
                    Operations.AddAndSet(op);
                    break;
                }
                case Operators.SUBS:
                {
                    Operations.SubsAndSet(op);
                    break;
                }
                case Operators.MUL:
                {
                    Operations.MulAndSet(op);
                    break;
                }
                case Operators.DIV:
                {
                    Operations.DivAndSet(op);
                    break;
                }
                default:
                    break;
            }
        }
        public static void CompleteHalfCompletedOperation(OperationIndex opIndex, Operation op) {
            List<Operators> possibleOperations = Operations.PossibleOperations(op);
            int randOperationIndex = MathOps.rd.Next(0,possibleOperations.Count);
            Operators _operator = (Operators)possibleOperations[randOperationIndex];
            op.Operator.SetOperator(_operator);
            op.Result.SetResult(MathOps.CalculateResult(_operator,op.LeftOperand.GetOperand(),op.RightOperand.GetOperand()));
        }
    
    }
}