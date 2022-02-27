using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

namespace FourOperations {

    [RequireComponent(typeof(CanvasGroup))]
    public class DraggableOperand : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IEndDragHandler,IDragHandler {
        private int value;
        private bool isPlaced = false;
        public Text operandText;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        public Canvas canvas;
        private Vector2 startAnchoredPosition;
        public void Awake() {
            this.rectTransform = GetComponent<RectTransform>();
            this.canvasGroup = GetComponent<CanvasGroup>();
        }
    
        public void SetValue(int value){
            this.value = value;
            this.operandText.text = this.value + "";
        }
        public int GetValue() {
            return this.value;
        }
        public void SetIsPlaced(bool isPlaced) {
            this.isPlaced = true;
        }
        public Vector2 GetAnchoredPosition(){
            return this.rectTransform.anchoredPosition;
        }
        public void SetAnchoredPosition(Vector2 anchoredPosition){
            this.rectTransform.anchoredPosition =anchoredPosition;
            this.startAnchoredPosition = anchoredPosition;
        }
        public void OnDrag(PointerEventData eventData) {
            if(!isPlaced)
                rectTransform.anchoredPosition+= eventData.delta / canvas.scaleFactor;
        }
        public void OnBeginDrag(PointerEventData eventData) {
            if(!isPlaced){
                startAnchoredPosition = rectTransform.anchoredPosition;
                canvasGroup.alpha = .6f;
                canvasGroup.blocksRaycasts = false;
                Debug.Log("OnBeginDrag");
            }
            
        }
        public void OnEndDrag(PointerEventData eventData) {
            if(!isPlaced){
                ResetPosition();
            }
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        public void OnPointerDown(PointerEventData eventData) {
            
        }
        public void ResetPosition(){
            rectTransform.anchoredPosition = this.startAnchoredPosition;
        }
    }
}