using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectData 
{
    public string name;
    public string description;
    public string ownerName;
    public string requiredBadgesIDs;
    string _projectID;
    public string projectID
    {
        get { return _projectID; }
        set { _projectID = value; }
    }

    public ProjectData( string n, string p, string d, string k)
    {
        name = n;
        ownerName = p;
        description = d;
        _projectID = k;

    }



}
