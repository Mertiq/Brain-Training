using System;
using System.Collections.Generic;
using System.Linq;
using MainMenu;
using UnityEngine;

public class SkillSystemManager
{
    public enum GameName
    {
        Cashier,
        Ten,
        FourOp,
        Fract,
        Percent,
        Time,
        Paint,
        Card
    }
    
    private static readonly Dictionary<GameName, float> Multiplier = new Dictionary<GameName, float>()
    {
        {GameName.Cashier, 16.67f},
        {GameName.Ten, 8.33f},
        {GameName.FourOp, 16.67f},
        {GameName.Fract, 16.67f},
        {GameName.Percent, 16.67f},
        {GameName.Time, 16.67f},
        {GameName.Paint, 20000},
        {GameName.Card, 50000}
    };
    
    public static void CalculateSkillPoint(Category skillName, GameName gameName, float point)
    {
        IncreaseSkillAndSave(skillName, (int) (Multiplier[gameName] * point));
    }

    public static void IncreaseSkillAndSave(Category skillName, int plusValue)
    {
        foreach (var skill in Resources.LoadAll<Skill>("Skills").Where(skill => skill.SkillName == skillName))
        {
            skill.CurrentValue += plusValue;
        }
    }
    
}
