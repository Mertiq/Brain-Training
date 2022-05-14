using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TopPanelAnimationController : MonoBehaviour
{
    public Utilities.TimeUIManager timeManager;
    private Tween DOScaleTween;

    void Awake()
    {
        //timeManager.AddOnTimeSetListener(AnimateTimer);
    }
    void AnimateTimer(GameObject timeObject)
    {
        Vector3 scaleVector = timeObject.transform.localScale;
        timeObject.transform.localScale = Vector3.zero;
        Sequence timeSequ = DOTween.Sequence();
        timeSequ.Append(timeObject.transform.GetComponent<TextMeshProUGUI>().DOFade(0.5f, 0.2f))
            .Append(timeObject.transform.GetComponent<TextMeshProUGUI>().DOFade(1, 0.5f));
        
        
    }

}
