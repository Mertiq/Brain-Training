using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerOfHanoi
{
    public class Block : MonoBehaviour
    {
        public BlockData blockData;

        private SpriteRenderer spriteRenderer;
        private Vector3 lastPosition;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = blockData.Color;
            blockData.isOnAbove = true;
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
                    if (stick.topBlock && stick.topBlock.blockData.size > blockData.size)
                    {
                        Debug.Log("sea");
                        return;                    }
                    else
                    {
                        ResetPosition();
                        return;
                    }
                }
            }

            ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = lastPosition;
        }
    }
}