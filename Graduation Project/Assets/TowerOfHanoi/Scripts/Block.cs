using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerOfHanoi
{
    public class Block : MonoBehaviour
    {
        public BlockData blockData;
        private Stick currentStick;

        private SpriteRenderer spriteRenderer;
        private Vector3 lastPosition;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = blockData.Color;
            FindCurrentStick();
        }

        public void OnFingerDown()
        {
            lastPosition = transform.position;
        }

        public void OnFingerUp()
        {
            Collider2D[] targetObject = Physics2D.OverlapPointAll(transform.position);

            foreach (Collider2D collider in targetObject)
            {
                Stick stick;

                if (collider.TryGetComponent<Stick>(out stick))
                {
                    if (stick.topBlock == null || stick.topBlock.blockData.size > blockData.size)
                    {
                        PlaceBlock(stick);
                        return;
                    }
                    else
                    {
                        ResetPosition();
                        return;
                    }
                }
            }

            ResetPosition();
        }

        private void FindCurrentStick()
        {
            Collider2D[] targetObject = Physics2D.OverlapPointAll(transform.position);
            foreach (Collider2D collider in targetObject)
            {
                if (collider.TryGetComponent<Stick>(out Stick stick))
                {
                    currentStick = stick;
                }
            }
        }

        private void PlaceBlock(Stick stick)
        {
            currentStick.RemoveBlock(this);
            stick.AddBlock(this);
            currentStick = stick;
        }

        private void ResetPosition()
        {
            transform.position = lastPosition;
        }
    }
}