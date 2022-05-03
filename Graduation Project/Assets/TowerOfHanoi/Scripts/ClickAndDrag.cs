using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerOfHanoi
{
    public class ClickAndDrag : MonoBehaviour
    {
        private Block selectedBlock;
        private Touch touch;
        private Vector3 _touchPosition;

        void Update()
        {
            if (Input.touches.Length > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    _touchPosition.z = -5;

                    Collider2D[] collidedObjects = Physics2D.OverlapPointAll(_touchPosition);
                    foreach (Collider2D collider in collidedObjects)
                    {
                        Block block;

                        if (collider.TryGetComponent<Block>(out block))
                        {
                            if (block.blockData.isOnAbove)
                            {
                                selectedBlock = block;
                                selectedBlock.OnFingerDown();
                            }
                        }
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    selectedBlock.OnFingerUp();
                    selectedBlock = null;
                }

                if (selectedBlock)
                {
                    _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    _touchPosition.z = -5;

                    selectedBlock.transform.position = _touchPosition;
                }
            }
        }
    }
}