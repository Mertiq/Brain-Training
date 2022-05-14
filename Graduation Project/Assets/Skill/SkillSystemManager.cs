using System;
using System.Linq;
using UnityEngine;

public class SkillSystemManager
{
    public enum PointType
    {
        RaceByTime,
        MakeTrue
    }

    public static float timeMultiplier;
    public static int trueMultiplier;
    
    public static void CalculateSkillPoint(string skillName, PointType pointType, float point)
    {
        switch (pointType)
        {
            case PointType.RaceByTime:
                IncreaseSkillAndSave(skillName,CalculateTimePoint(point));
                break;
            case PointType.MakeTrue:
                IncreaseSkillAndSave(skillName,CalculateTruePoint(point));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(pointType), pointType, null);
        }
    }
    
    public static void IncreaseSkillAndSave(string skillName, int plusValue)
    {
        foreach (var skill in Resources.LoadAll<Skill>("Skills").Where(skill => skill.SkillName == skillName))
        {
            skill.CurrentValue += plusValue;
        }
    }
    
    private static int CalculateTimePoint(float point)
    {
        return (int) (point * timeMultiplier);
    }

    private static int CalculateTruePoint(float point)
    {
        return (int) point * trueMultiplier;
    }
    
}
