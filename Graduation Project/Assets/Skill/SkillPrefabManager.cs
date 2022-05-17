using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPrefabManager : MonoBehaviour
{
     [SerializeField] private Text skillNameText;
     [SerializeField] private TextMeshProUGUI skillValueText;
     [SerializeField] private Slider slider;

     public Text SkillNameText
     {
          get => skillNameText;
          set => skillNameText = value;
     }

     public Slider Slider
     {
          get => slider;
          set => slider = value;
     }

     public TextMeshProUGUI SkillValueText
     {
          get => skillValueText;
          set => skillValueText = value;
     }
}
