using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace FourOperations{
    public class Operand : MonoBehaviour,IDropHandler {
        public Text operandText;
        private int operand;
        private int guessedOperand;
        private bool isGuessed = false;
        private bool isHint = false;
        private bool isCorrectlyGuessed = false;
        private GameObject placedGuessOperand;
        private System.Action onDrop;

        public void AddOnDropListener(System.Action action){
            onDrop+= action;
        }
        public void RemoveOnDropListener(System.Action action){
            onDrop-= action;
        }
        public int GetOperand() {
            return this.operand;
        }
        public void SetOperand(int operand) {
            this.operand = operand;
        }
        public int GetGuessedOperand() {
            return this.guessedOperand;
        }
        public void SetGuessedOperand(int operand) {
            this.guessedOperand = operand;
            this.isGuessed = true;
            this.operandText.text = this.guessedOperand + "";
            this.isCorrectlyGuessed = this.operand == this.guessedOperand; 
        }
        public void SetIsHint(bool isHint) {
            this.isHint = true;
        }
        public bool GetIsHint() {
            return this.isHint;
        }
        public bool GetIsGuessed(){
            return this.isGuessed;
        }
        public bool GetIsCorrectlyGuessed() {
            return this.isCorrectlyGuessed;
        }
        public void OnDrop(PointerEventData eventData) {
            if(!isHint && placedGuessOperand == null && eventData.pointerDrag != null) {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DraggableOperand>().SetIsPlaced(true);
                placedGuessOperand = eventData.pointerDrag;
                this.SetGuessedOperand(eventData.pointerDrag.GetComponent<DraggableOperand>().GetValue());
                onDrop?.Invoke();
            }
        }
    }
}