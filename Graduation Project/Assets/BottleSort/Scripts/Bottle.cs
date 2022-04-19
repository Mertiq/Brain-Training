using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utilities;
namespace BottleSort {

    public enum BottlePlace {
        LEFT = 0, MIDDLE, RIGHT
    } 

    public class Bottle : MonoBehaviour {
        private Stack balls;
        public BottlePlace place;
        public RectTransform dropBallTransform;
        private System.Action onPush;
        private System.Action onPop;

        public void AddOnPushListener(System.Action action)
        {
            onPush += action;
        }
        public void AddOnPopListener(System.Action action)
        {
            onPop += action;
        }
        private void Awake() {
            balls = new Stack(ResourceManager.BOTTLE_CAPACITY);

        }
        public bool PutBall(Ball ball) {
            if (balls.Count >= ResourceManager.BOTTLE_CAPACITY) {
                return false;
            }
            balls.Push(ball);
            onPush?.Invoke();
            return true;
        }
        private void Update()
        {

        }
        public Ball PopBall() {
            Ball ball = (Ball)(balls.Pop());
            if (ball != null) {
                onPop?.Invoke();
            }
            return ball;
        }
    }
}