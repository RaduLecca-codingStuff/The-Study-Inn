using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectData 
{
    public string name;
    public string description;
    string _projectID;
    public string projectName
    {
        get { return _projectID; } 
        set { _projectID = value; }
    }
    List<string> _skillsRequired;

  
   
}
