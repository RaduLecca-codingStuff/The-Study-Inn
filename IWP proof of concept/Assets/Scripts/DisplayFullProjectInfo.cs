using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFullProjectInfo : MonoBehaviour
{
    ProjectData projectData;
    Text Title;
    Text Description;
    GameObject badgePrefab;
    GameObject badgeParent;
    List<GameObject> requiredBadges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PresentProject()
    {
        if (projectData != null)
        {
            Title.text = projectData.name;
            Description.text = projectData.description;
            foreach(Badge badge in projectData.SkillsRequired)
            {
                GameObject b =Instantiate(badgePrefab);
                b.GetComponent<Text>().text = badge.name;
                b.transform.SetParent(badgeParent.transform);
                requiredBadges.Add(b);
            }
        }
    }
}
