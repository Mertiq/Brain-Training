using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MemoryMatchingGame
{
	public class CardGenerator : MonoBehaviour
	{
		Sprite[] resourcesCards;
		Sprite[] resourcesCardNamesEnglish;

		List<Sprite> cardSpritesList1 = new List<Sprite>();
		List<Sprite> cardSpritesList2 = new List<Sprite>();

		private GameObject cardsParentObject;
		private void Awake()
		{
			// Resources/Card directory
			resourcesCards = Resources.LoadAll<Sprite>("Memory Matching Game/Cards");
			resourcesCardNamesEnglish = Resources.LoadAll<Sprite>("Memory Matching Game/CardNames/English");

			foreach (var item in resourcesCards)
			{
				cardSpritesList1.Add(item);
				cardSpritesList2.Add(item);
			}

			//in hierarchy there is an object that name is Cards. It is the parent of all cards in the scene.
			cardsParentObject = GameObject.Find("Cards");

			GenerateCards(cardSpritesList1.Count);
		}

		private void GenerateCards(int count)
		{
			for (var i = 0; i < count; i++)
			{
				var rand = Random.Range(0, cardSpritesList1.Count);

				while (cardSpritesList1[rand] == null)
				{
					rand = Random.Range(0, cardSpritesList1.Count);
				}

				cardsParentObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = cardSpritesList1[rand];
				cardsParentObject.transform.GetChild(i).transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = GetCardName(cardSpritesList1[rand].name);
				cardSpritesList1.RemoveAt(rand);

			}

			for (var i = count; i < count * 2; i++)
			{
				var rand = Random.Range(0, cardSpritesList2.Count);

				while (cardSpritesList2[rand] == null)
				{
					rand = Random.Range(0, cardSpritesList2.Count);
				}

				cardsParentObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = cardSpritesList2[rand];
				cardsParentObject.transform.GetChild(i).transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = GetCardName(cardSpritesList2[rand].name);
				cardSpritesList2.RemoveAt(rand);

			}
		}

		private Sprite GetCardName(string name)
		{
			return resourcesCardNamesEnglish.FirstOrDefault(cardName => cardName.name == name);
		}
	}
}

