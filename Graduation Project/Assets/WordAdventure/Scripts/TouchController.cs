using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WordAdventure
{
    public enum TouchDirection { Right, Left, Up, Down, Tapped };

    public class TouchController : MonoBehaviour
    {
        private Touch theTouch;
        private Vector2 touchStartPos, touchEndPos;
        private TouchDirection direction;

        /*public delegate void OnTouchDown(TouchDirection td);
        public static event OnTouchDown onTouchDown;*/
        public static Action<TouchDirection> OnTouchDown;

        void Update()
        {
            if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);

                if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPos = theTouch.position;
                }
                else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPos = theTouch.position;

                    float x = touchEndPos.x - touchStartPos.x;
                    float y = touchEndPos.y - touchStartPos.y;

                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        direction = TouchDirection.Tapped;
                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        direction = x > 0 ? TouchDirection.Right : TouchDirection.Left;
                    }
                    else
                    {
                        direction = y > 0 ? TouchDirection.Up : TouchDirection.Down;
                    }

                    OnTouchDown?.Invoke(direction);
                }
            }
        }
    }
}