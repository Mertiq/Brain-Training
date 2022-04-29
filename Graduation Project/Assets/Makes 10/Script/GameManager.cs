using System;
using UnityEngine;

namespace Makes_10.Script
{
	public class GameManager : MonoBehaviour
	{
		//choosen Ball gameObjects
		[SerializeField] private GameObject firstBallObject = null;
		[SerializeField] private GameObject secondBallObject = null;

		//choosen Balls
		[SerializeField] private Ball firstBall = null;
		[SerializeField] private Ball secondBall = null;

		[SerializeField] private int clickCounter;
		[SerializeField] private bool canClick = true;
		
		[SerializeField] private bool isGameEnd;
		[SerializeField] public static int score;
		[SerializeField] private int gameEndTime;
		
		
		public delegate void GameEnd ();
		public static event GameEnd OnGameEnd;  
		public delegate void ScoreChanged(int score);
		public static event ScoreChanged OnScoreChanged;

		private void Start()
		{
			FindObjectOfType<AudioManager>().PlaySound("background");
		}

		private void Update()
		{
			if (canClick)
			{
				if (Input.GetMouseButtonDown(0))
				{
					var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

					if (Physics.Raycast(ray, out var hit, 100))
					{
						// Ball objects have Ball tag
						if (hit.collider.CompareTag("Ball"))
						{
							if (clickCounter == 0)
							{
								FindObjectOfType<AudioManager>().PlaySound("pick ball");
								firstBallObject = hit.collider.gameObject;
								firstBall = firstBallObject.GetComponent<Ball>();
								firstBall.GlowCirleSetActive(true);
								clickCounter++;
							}
							else
							{
								FindObjectOfType<AudioManager>().PlaySound("pick ball");
								secondBallObject = hit.collider.gameObject;
								secondBall = secondBallObject.GetComponent<Ball>();
								secondBall.GlowCirleSetActive(true);

								canClick = false;

								//check ball
								Invoke(nameof(Control), .5f);

								clickCounter = 0;
							}
						}
					}
				}
			}
			
			if (!(Timer.currentTime >= gameEndTime)) return;
			isGameEnd = true;
			OnGameEnd?.Invoke();
		}

		private void Control()
		{
			if (firstBall.number + secondBall.number == 10)
			{
				FindObjectOfType<AudioManager>().PlaySound("correct match");
				Destroy(firstBallObject);
				Destroy(secondBallObject);
				score += 10;
				OnScoreChanged?.Invoke(score);
			}
			else
			{
				FindObjectOfType<AudioManager>().PlaySound("wrong match");
				score -= 10;
				OnScoreChanged?.Invoke(score);
			}
			canClick = true;
			firstBall.GlowCirleSetActive(false);
			secondBall.GlowCirleSetActive(false);
		}
	}
}



