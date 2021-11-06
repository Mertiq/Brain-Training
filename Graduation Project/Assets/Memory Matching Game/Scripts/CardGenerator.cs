using System.Collections.Generic;
using UnityEngine;

namespace MemoryMatchingGame
{
	public class CardGenerator : MonoBehaviour
	{
		Sprite[] resourcesObjects;

		List<Sprite> cardSpritesList1 = new List<Sprite>();
		List<Sprite> cardSpritesList2 = new List<Sprite>();

		GameObject cardsParentObject;
		private void Awake()
		{
			// Resources/Card directory
			resourcesObjects = Resources.LoadAll<Sprite>("Memory Matching Game");

			foreach (Sprite item in resourcesObjects)
			{
				cardSpritesList1.Add(item);
				cardSpritesList2.Add(item);
			}

			//in hierarchy there is an object that name is Cards. It is the parent of all cards in the scene.
			cardsParentObject = GameObject.Find("Cards");

			GenerateCards(cardSpritesList1.Count);
		}

		void GenerateCards(int count)
		{
			for (int i = 0; i < count; i++)
			{
				int rand = Random.Range(0, cardSpritesList1.Count);

				while (cardSpritesList1[rand] == null)
				{
					rand = Random.Range(0, cardSpritesList1.Count);
				}

				cardsParentObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = cardSpritesList1[rand];
				cardSpritesList1.RemoveAt(rand);

			}

			for (int i = count; i < count * 2; i++)
			{
				int rand = Random.Range(0, cardSpritesList2.Count);

				while (cardSpritesList2[rand] == null)
				{
					rand = Random.Range(0, cardSpritesList2.Count);
				}

				cardsParentObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = cardSpritesList2[rand];
				cardSpritesList2.RemoveAt(rand);

			}
		}
	}
}

