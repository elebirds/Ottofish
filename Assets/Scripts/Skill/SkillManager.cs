using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    public SkillBase bs;
    public Dictionary<string, Skill> skills;
    public string prepareName;

    public void init()
    {
        skills["������"] = new Skill("������", ElementType.ICE, 10f, 1, 0.83f, 2f, "Prefab/Skill/icemagic", "Prefab/Skill/skillRange");
        skills["�������"] = new Skill("�������", ElementType.FIRE, 80f, 2, 1.5f, 5f,"Prefab/Skill/fireMagic", "Prefab/Skill/skill2Range");
    }

    public void prepareCall(string name)
    {
        this.prepareName = name;
        bs.isPreparing = true;
        skills[name]?.generateDistance();
    }

    public void callSkill(Vector3 pos, bool byPlayer = false)
    {
        callSkill(prepareName, pos,byPlayer);
    }

    public void callSkill(string name,Vector3 pos,bool byPlayer = false)
    {
        bs.isPreparing = false;
        skills[name]?.generate(pos,byPlayer);
    }

    private static SkillManager _instance;
    public static SkillManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SkillManager();
            }
            return _instance;
        }
    }
    private SkillManager()
    {
        skills = new Dictionary<string, Skill>();
    }
}
