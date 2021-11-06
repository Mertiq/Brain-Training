using UnityEngine;

namespace MemoryMatchingGame
{
	public class Card : MonoBehaviour
	{
		public string cardType;

		private void Start()
		{
			//type of card is the name of the sprite that card object has
			cardType = GetComponent<SpriteRenderer>().sprite.name;
		}

	}
}

