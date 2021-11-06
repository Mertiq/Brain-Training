using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class CategoryPanelManager : MonoBehaviour
    {
        public GameObject CategoryCard;
        public GameObject viewport;
        public GamePanelManager gmp;

        private void Start()
        {
            foreach (var category in Category.GetNames(typeof(Category)))
            {
                GameObject card= Instantiate(CategoryCard, viewport.transform);
                card.GetComponent<CategoryCard>().SetName(category);
                card.GetComponent<Button>().onClick.AddListener(() => gmp.InitializeGameCards(category));
                card.GetComponent<Button>().onClick.AddListener(() => gameObject.SetActive(false));
            }
        }
    }
}
