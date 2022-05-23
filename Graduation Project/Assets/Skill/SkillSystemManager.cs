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
        Card,
        Lamps,
        Reflection,
    }
    
    public static readonly Dictionary<GameName, float> Multiplier = new Dictionary<GameName, float>()
    {
        {GameName.Cashier, 16.67f},
        {GameName.Ten, 8.33f},
        {GameName.FourOp, 20.1f},
        {GameName.Fract, 16.67f},
        {GameName.Percent, 16.67f},
        {GameName.Time, 20.1f},
        {GameName.Paint, 20000f},
        {GameName.Card, 50000f},
        {GameName.Lamps, 20000f},
        {GameName.Reflection, 50000f},
    };
    
    public static void CalculateSkillPoint(Category skillName, GameName gameName, float point)
    {
        IncreaseSkillAndSave(skillName, (int) (Multiplier[gameName] * point));
        Debug.Log((int)(Multiplier[gameName] * point));
    }

    public static void IncreaseSkillAndSave(Category skillName, int plusValue)
    {
        foreach (var skill in Resources.LoadAll<Skill>("Skills").Where(skill => skill.SkillName == skillName))
        {
            skill.CurrentValue += plusValue;
        }
    }
    
}
