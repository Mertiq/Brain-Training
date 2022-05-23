using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    
    
    private void Start()
    {
        SmallToNormal(mainPanel);
    }

    public void SmallToBigToNormal(GameObject gameObject)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOScale(0, 0.01f)).
                Append(gameObject.transform.DOScale(2f, .7f)).
                Append(gameObject.transform.DOScale(1, .5f));
    }
    
    public void SmallToBigToNormalWithShake(GameObject go)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(go.transform.DOShakeScale(.9f, .8f, 5, 90, true));
    }
    
    public void SmallToNormal(GameObject go)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(go.transform.DOScale(0.3f, .01f)).
            Append(go.transform.DOScale(1, .5f));
    }

    public static void LittleLittleShake(GameObject go)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(go.transform.DOShakeScale(1f,0.1f));
    }

    public static void FadeInAnim(GameObject go)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(go.GetComponent<Image>().DOFade(1f,0.5f));
    }
    
    public static void FadeOutAnim(GameObject go)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(go.GetComponent<Image>().DOFade(0f,0.7f));
    }
}
