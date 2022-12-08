using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class ProjectScrollerScript : MonoBehaviour
{
    List<ProjectData> projects = new List<ProjectData>();
    public GameObject optionBase;
    GameObject ScrollParent;
    public ButtonScripts bScripts;
    //public GameObject ProjDetailsPopUp;
    string[] projDataStrings;
    string path;
    public void ReadString()
    {
        path = "Assets/DataFiles/ProjectListFile.pdata";
        Resources.Load(path);
        StreamReader reader = new StreamReader(path);
        projDataStrings = reader.ReadToEnd().Split('~');
        reader.Close();

        for (int i = 0; i < projDataStrings.Length; i++)
        {
            string[] indivSegments = projDataStrings[i].Split('`');
            string[] skillsrequired = indivSegments[4].Split(',');
            if(skillsrequired.Length > 0 && indivSegments.Length>0)
            {
                List<Badge> badges = new List<Badge>();
                foreach (string skill in skillsrequired)
                {
                    int sk;
                    bool isParsable = Int32.TryParse(skill, out sk);
                    if (isParsable)
                        badges.Add(new Badge(Badge.IntToSkill(sk)));
                }
                ProjectData data = new ProjectData(badges, indivSegments[1].Trim(), indivSegments[2].Trim(), indivSegments[3].Trim(), indivSegments[0].Trim());
                projects.Add(data);
            }
            
        }
        
        
    }
    private void Awake()
    {
        ScrollParent = GameObject.FindWithTag("SearchProjList");
    }
    // Start is called before the first frame update
    void Start()
    {
        ReadString();
        GameObject option;
        
        for(int i = 0; i < projects.Count; i++)
        {
            option = Instantiate(optionBase);
            SetButtons(option.GetComponentInChildren<Button>(), projects[i]);
            option.GetComponent<DisplayProject>().SetProjectData(projects[i]);
            option.transform.SetParent(ScrollParent.transform);
        }
        
    }
    void SetButtons(Button button,ProjectData pr)
    {
        button.onClick.AddListener(()=> bScripts.OpenDetailsWindow(pr));
    }
    void SetString( string str)
    {
        string[] indivSegments = str.Split('`');
        string[] skillsrequired = indivSegments[3].Split(',');

    }
}
