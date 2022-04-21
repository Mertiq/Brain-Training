using UnityEngine;
using UnityEngine.UI;

namespace Makes10
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

		public delegate void OnScoreChange(float score);
		public static event OnScoreChange onScoreChange;
		
		private void Update()
		{
			if (canClick)
			{
				if (Input.GetMouseButtonDown(0))
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;

					if (Physics.Raycast(ray, out hit, 100))
					{
						// Ball objects have Ball tag
						if (hit.collider.CompareTag("Ball"))
						{
							if (clickCounter == 0)
							{
								//assign ball
								firstBallObject = hit.collider.gameObject;
								firstBall = firstBallObject.GetComponent<Ball>();
								firstBall.GlowCirleSetActive(true);

								clickCounter++;
							}
							else
							{
								//assign ball
								secondBallObject = hit.collider.gameObject;
								secondBall = secondBallObject.GetComponent<Ball>();
								secondBall.GlowCirleSetActive(true);

								canClick = false;

								//check ball
								Invoke("Control", .5f);

								clickCounter = 0;
							}
						}
					}
				}
			}
		}

		private void Control()
		{
			if (firstBall.number + secondBall.number == 10)
			{
				Destroy(firstBallObject);
				Destroy(secondBallObject);
				ScoreManager.score += 10;
				onScoreChange(ScoreManager.score);
			}
			canClick = true;
			firstBall.GlowCirleSetActive(false);
			secondBall.GlowCirleSetActive(false);
		}
	}
}



