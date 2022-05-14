using UnityEngine;

public class SkillsUIManager : MonoBehaviour
{
    [SerializeField] private GameObject skillPrefab;
    [SerializeField] private Skill[] resourcesSkills;

    private void Start()
    {
        InitializeSkillUI();
    }

    private void InitializeSkillUI()
    {
        resourcesSkills = Resources.LoadAll<Skill>("Skills");
        foreach (var skill in resourcesSkills)
        {
            var card = Instantiate(skillPrefab, transform);
            var skillPrefabManager = card.GetComponent<SkillPrefabManager>();
            skillPrefabManager.SkillNameText.text = skill.SkillName.ToString();
            skillPrefabManager.Slider.value = (float) skill.CurrentValue / skill.MaxValue;
            skillPrefabManager.SkillValueText.text = $"{skill.CurrentValue}/{skill.MaxValue}";
        }
    }
    
}
