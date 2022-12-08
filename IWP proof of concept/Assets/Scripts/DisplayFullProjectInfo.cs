using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFullProjectInfo : MonoBehaviour
{
    ProjectData projectData;
    public Text Title;
    public Text Owner;
    public Text Description;
    public GameObject badgePrefab;
    public GameObject badgeParent;
    // Start is called before the first frame update

    public void SelectProject(ProjectData project)
    {
        projectData=project;
        if (projectData != null)
        {
            Title.text = projectData.name;
            Owner.text = projectData.publisher;
            Description.text = projectData.description;
           
            foreach (Badge badge in projectData.SkillsRequired)
            {
                GameObject newBadge = Instantiate(badgePrefab);
                newBadge.GetComponentInChildren<Text>().text = badge.BadgeName;
                newBadge.transform.SetParent(badgeParent.transform);
            }
            
        }

    }
    }
