using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ColorfulLambs
{

    public class Light : MonoBehaviour, IPointerDownHandler
    {
        public int index;
        private SpriteRenderer turnOnSprite;
        private BoxCollider2D col;

        void Start()
        {
            turnOnSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
            col = GetComponent<BoxCollider2D>();
        }

        public void TurnOnLight()
        {
            turnOnSprite.enabled = true;
        }

        public void EnableInteraction()
        {
            col.enabled = true;
        }

        public void DisableInteraction()
        {
            col.enabled = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            GameManager.onClickLight?.Invoke(this.index);
        }
    }
}
