using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

[Serializable]
public class ProjectScrollerScript : MonoBehaviour
{
    List<ProjectData> projects = new List<ProjectData>();
    public GameObject optionBase;
    GameObject ScrollParent;
    public ButtonScripts bScripts;
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
        LoadData();
        //ReadString();
        Debug.Log(projects.Count);
        
        
        
        
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

    public void EditSearchTerm(Text term)
    {
        if (term.text!="")
        foreach(ProjectData pr in projects)
        {
            if (!pr.name.Contains(term.text) && !pr.ownerName.Contains(term.text))
            {
                ScrollParent.transform.Find(pr.name).gameObject.SetActive(false);
            }
        }
        else
        for (int i = 0; i < ScrollParent.transform.childCount; i++)
        {
            ScrollParent.transform.GetChild(i).gameObject.SetActive(true);
        }

    }

    public void LoadData()
    {
        string url = GameManager.DATA_URL;
        FirebaseDatabase.DefaultInstance
            .GetReference("ProjectList")
            .GetValueAsync()
            .ContinueWithOnMainThread((task=> {

                if (task.IsCanceled)
                {
                    Debug.LogError("DATA RETRIEVAL CANCELLED");
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("DATA IS SOMEHOW BROKEN");
                }
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    string playerData= snapshot.GetRawJsonValue();
                    foreach(var child in snapshot.Children)
                    {
                        string t = child.GetRawJsonValue();
                        ProjectData proj = JsonUtility.FromJson<ProjectData>(t);
                        projects.Add(proj);
                        
                        
                    }
                    Debug.Log(projects.Count);

                    GameObject option;
                    for (int i = 0; i < projects.Count; i++)
                    {
                        option = Instantiate(optionBase);
                        SetButtons(option.GetComponentInChildren<Button>(), projects[i]);
                        option.GetComponent<DisplayProject>().SetProjectData(projects[i]);
                        option.transform.SetParent(ScrollParent.transform);
                        option.gameObject.name = projects[i].name;
                    }
                }
            
            
            }));
    }
}
