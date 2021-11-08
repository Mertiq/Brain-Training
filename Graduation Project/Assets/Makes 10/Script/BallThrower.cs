using UnityEngine;
 
namespace Makes10
{
	public class BallThrower : MonoBehaviour
	{
		GameObject ballThrowersParent;

		Transform ballThrower;

		GameObject[] balls;

		float timeCounter;

		private void Start()
		{
			ballThrowersParent = GameObject.Find("BallThrowers");
			balls = Resources.LoadAll<GameObject>("Makes 10/Balls");
		}

		private void Update()
		{
			timeCounter += Time.deltaTime;
			if (timeCounter > 1)
			{
				ThrowBall();
				timeCounter = 0;
			}
		}

		void ThrowBall()
		{
			ballThrower = ballThrowersParent.transform.GetChild(Random.Range(0, 4));
			if (ballThrower.transform.childCount <= 4)
			{
				Instantiate(balls[Random.Range(0, 9)], ballThrower);
			}
			else
			{
				Destroy(ballThrower.GetChild(0).gameObject);
			}
		}

	}

}

