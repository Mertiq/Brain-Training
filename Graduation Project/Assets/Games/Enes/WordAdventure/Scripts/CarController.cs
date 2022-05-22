using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace WordAdventure
{
    public class CarController : MonoBehaviour
    {
        string st = "BCDEOHPRSUV";

        [SerializeField] private GameManager GameManager;
        [SerializeField] private GameObject RoadObject;
        [SerializeField] private GameObject CarObject;
        [SerializeField] private GameObject Letters;
        [SerializeField] private float speed;

        private Sequence turnSequence;
        private int currentLane;
        void Start()
        {
            turnSequence = DOTween.Sequence();
            currentLane = 0;
            TouchController.OnTouchDown += RaiseTouchDownEvent;
            StartCoroutine(MoveCarTowards(100f));
        }

        private IEnumerator MoveCarTowards(float duration)
        {
            float elapsedTime = 0f;
            float takenWay = 0f;

            while (elapsedTime < duration)
            {
                transform.Translate(0f, 0f, speed * Time.deltaTime);
                takenWay += speed * Time.deltaTime;
                elapsedTime += Time.deltaTime;

                if (takenWay > 100f)
                {
                    RoadObject.transform.Translate(0f, 0f, takenWay);
                    Letters.transform.Translate(0f, 0f, takenWay);
                    takenWay = 0f;
                }

                yield return null;
            }

            if (elapsedTime > duration)
            {
                yield break;
            }
        }

        private void RaiseTouchDownEvent(TouchDirection td)
        {
            switch (td)
            {
                case TouchDirection.Right:
                    TurnRight();
                    break;
                case TouchDirection.Left:
                    TurnLeft();
                    break;
            }

            StartCoroutine(WaitForNextChangeLane());
        }

        private void TurnLeft()
        {
            ChangeLane(-1);
            float pos = GetLanePosition();

            turnSequence.Append(transform.DORotate(new Vector3(0f, -8.45f, 0f), 0.15f).
                OnComplete(() => transform.DORotate(new Vector3(0f, 4.25f, 0f), 0.3f)).
                OnComplete(() => transform.DORotate(new Vector3(0f, 0f, 0f), 0.15f)));
            turnSequence.Append(transform.DOMoveX(pos + 0.24f, 0.3f).
                OnComplete(() => transform.DOMoveX(pos, 0.3f)));
        }

        private void TurnRight()
        {
            ChangeLane(1);
            float pos = GetLanePosition();

            turnSequence.Append(transform.DORotate(new Vector3(0f, 8.45f, 0f), 0.15f).
                OnComplete(() => transform.DORotate(new Vector3(0f, -4.25f, 0f), 0.3f)).
                OnComplete(() => transform.DORotate(new Vector3(0f, 0f, 0f), 0.15f)));
            turnSequence.Append(transform.DOMoveX(pos - 0.24f, 0.3f).
                OnComplete(() => transform.DOMoveX(pos, 0.3f)));
        }

        private float GetLanePosition()
        {
            if (currentLane == -1)
            {
                return -3.5f;
            }
            else if (currentLane == 0)
            {
                return 0;
            }
            else
            {
                return 3.5f;
            }
        }

        private void ChangeLane(int direction)
        {
            if (direction == -1)
            {
                if (currentLane != -1)
                {
                    currentLane -= 1;
                }
            }
            else
            {
                if (currentLane != 1)
                {
                    currentLane += 1;
                }
            }
        }

        private IEnumerator WaitForNextChangeLane()
        {
            TouchController.OnTouchDown -= RaiseTouchDownEvent;
            yield return new WaitForSeconds(0.5f);
            TouchController.OnTouchDown += RaiseTouchDownEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            Letter l = other.gameObject.GetComponent<Letter>();

            if (l.Lane == currentLane)
            {
                GameManager.AddCaughtLetter(l.letter);
            }

            StartCoroutine(ChangeLetterRoutine(2f, l));
        }

        private IEnumerator ChangeLetterRoutine(float time, Letter l)
        {
            yield return new WaitForSeconds(time);
            int lane = Random.Range(-1, 2);
            char c = st[Random.Range(0, st.Length)];
            l.SetLetter(lane, c.ToString());
        }

    }
}