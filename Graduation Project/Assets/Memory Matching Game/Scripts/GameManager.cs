using System.Collections.Generic;
using UnityEngine;

namespace MemoryMatchingGame
{
	public class GameManager : MonoBehaviour
	{
		//choosen Card gameObjects
		GameObject firstCardObject = null;
		GameObject secondCardObject = null;

		//choosen Cards
		Card firstCard = null;
		Card secondCard = null;

		int clickCounter;
		bool canClick = true;

		List<GameObject> cards = new List<GameObject>();

		private void Start()
		{
			GameObject cardsParent = GameObject.Find("Cards");

			for (int i = 0; i < cardsParent.transform.childCount; i++)
			{
				cards.Add(cardsParent.transform.GetChild(i).gameObject);
			}

		}

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
						if (clickCounter == 0)
						{
							//assign card
							firstCardObject = hit.collider.gameObject;
							firstCard = firstCardObject.GetComponent<Card>();

							//turn card
							firstCardObject.GetComponent<Animator>().SetBool("turn", true);

							clickCounter++;
						}
						else
						{
							//assign card
							secondCardObject = hit.collider.gameObject;
							secondCard = secondCardObject.GetComponent<Card>();

							//turn card
							secondCardObject.GetComponent<Animator>().SetBool("turn", true);

							canClick = false;

							//check card
							Invoke("Control", 1.8f);

							clickCounter = 0;
						}
					}
				}
			}
		}

		void Control()
		{
			if (firstCard.name != secondCard.name)
			{
				if (firstCard.cardType == secondCard.cardType)
				{
					firstCardObject.SetActive(false);
					secondCardObject.SetActive(false);

					//if all cards in the scene are active false, you win
					foreach (var item in cards)
					{
						if (item.activeSelf)
						{
							canClick = true;
							return;
						}
					}
					Debug.Log("win");
				}
				else
				{
					//turn card
					firstCardObject.GetComponent<Animator>().SetBool("turn", false);
					secondCardObject.GetComponent<Animator>().SetBool("turn", false);
				}
				canClick = true;
			}
		}
	}
}

