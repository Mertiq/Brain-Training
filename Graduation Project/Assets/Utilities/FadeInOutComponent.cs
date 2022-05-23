using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Utilities
{
    [RequireComponent(typeof(Image))]
    public class FadeInOutComponent : MonoBehaviour
    {
        private Image image;
        public bool isFadeInAnimation;

        private void Awake()
        {
            image = GetComponent<Image>();
            var fadeImage = Color.black;
            fadeImage.a = (isFadeInAnimation) ? 0 : 255;

            image.raycastTarget = false;
            image.color = fadeImage;
        }

        private void Start()
        {
            if(isFadeInAnimation)
            {
                MainMenuAnimationController.FadeInAnim(gameObject);
            }else
            {
                MainMenuAnimationController.FadeOutAnim(gameObject);
            }
        }

    }
}