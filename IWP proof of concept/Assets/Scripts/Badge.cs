using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour
{
    public enum Skill
    {
        Marketing,
        DigitalArt,
        C,
        Cplusplus,
        CSharp,
        Java,
        Javascript,
        HTML,
        CSS,
        Maya3DModelling,
        Blender3DModelling,
        UnityDesigner,
        UnrealDesigner,
        None,


    };
    public Skill skill;
    public string BadgeName;
    public Badge(Skill i)
    {
        SetBadgeSkill(i);
    }
    public static Skill IntToSkill(int s)
    {
        switch(s)
        {
            case 0:
                return Skill.Marketing;
            case 1:
                return Skill.DigitalArt;
            case 2:
                return Skill.C;
            case 3:
                return Skill.Cplusplus;
            case 4:
                return Skill.CSharp;
            case 5:
                return Skill.Java;
            case 6:
                return Skill.Javascript;
            case 7:
                return Skill.HTML;
            case 8:
                return Skill.CSS;
            case 9:
                return Skill.Maya3DModelling;
            case 10:
                return Skill.Blender3DModelling;
            case 11:
                return Skill.UnityDesigner;
            case 12:
                return Skill.UnrealDesigner;
            default:
                return Skill.None;

        }
    }
    public void SetBadgeSkill(Skill s)
    {
        skill = s;
        switch (s)
        {
            case Skill.Marketing:
                BadgeName = "Marketing";
                break;
            case Skill.DigitalArt:
                BadgeName = "Digital Art";
                break;
            case Skill.C:
                BadgeName = "C";
                break;
            case Skill.Cplusplus:
                BadgeName = "C++";
                break;
            case Skill.CSharp:
                BadgeName = "C#";
                break;
            case Skill.Java:
                BadgeName = "Java";
                break;
            case Skill.Javascript:
                BadgeName = "JavaScript";
                break;
            case Skill.HTML:
                BadgeName = "HTML";
                break;
            case Skill.CSS:
                BadgeName = "CSS";
                break;
            case Skill.Maya3DModelling:
                BadgeName = "Maya 3D Model";
                break;
            case Skill.Blender3DModelling:
                BadgeName = "Blender 3D Model";
                break;
            case Skill.UnityDesigner:
                BadgeName = "Unity Designer";
                break;
            case Skill.UnrealDesigner:
                BadgeName = "Unreal Designer";
                break;

        }
    }
}
