using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectData 
{
    public string name;
    public string description;
    public string publisher;
    string _projectID;
    public string projectID
    {
        get { return _projectID; } 
        set { _projectID = value; }
    }
    List<Badge> _skillsRequired;
    public List<Badge> SkillsRequired
    {
        get { return _skillsRequired; }
        set { _skillsRequired = value; }
    }

    public ProjectData(List<Badge> b,string n, string p, string d, string k) 
    { 
        _skillsRequired = b;
        name = n;
        publisher = p;
        description = d;
        _projectID = k;

    }

    
   
}
