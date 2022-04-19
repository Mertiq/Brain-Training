using System;

namespace FourOperations {

    public static class MathOps{
        public static Random rd = new Random();
        public static bool IsDivisible(int number, int divider) {
            return ( (number >= divider) && ( number % divider == 0));
        }
        public static bool IsSubstractable(int number, int substractor) {
            return number >= substractor;
        }
        public static bool IsMultiplyable(int number, int multiplier) {
            return (number > ResourceManager.mulMinOperand ) && (number < ResourceManager.mulMaxOperand) && 
                (multiplier > ResourceManager.mulMinOperand) && (multiplier < ResourceManager.mulMaxOperand);
        }
        public static bool isAddable(int number, int addition){
            return (number + addition < 100);
        }
        public static int CalculateResult(Operators _operator,int num1, int num2){
            switch(_operator){
                case Operators.ADD:
                {
                    return num1 + num2;
                }
                case Operators.SUBS:
                {
                    return num1 - num2;
                }
                case Operators.MUL:
                {
                    return num1 * num2;
                }
                case Operators.DIV:
                {
                    return num1 / num2;
                }
                default:
                    return -1;
            }
        }
       
    }
}