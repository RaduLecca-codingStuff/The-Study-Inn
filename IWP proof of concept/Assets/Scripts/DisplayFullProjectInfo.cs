using Firebase.Database;
using Firebase.Extensions;
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
    public Button JoinButton;
    
    string[] badgeIDs;
    // Start is called before the first frame update

    public void SelectProject(ProjectData project)
    {
        projectData = project;
        if (projectData != null)
        {
            Title.text = projectData.name;
            Owner.text = projectData.ownerName;
            Description.text = projectData.description;
            badgeIDs = project.requiredBadgesIDs.Split(',');
            LoadBadgeData();

        }

    }
    void LoadBadgeData()
    {
        foreach (Transform child in badgeParent.transform)
        {
            Destroy(child.gameObject);
        }
        string url = GameManager.DATA_URL;
        FirebaseDatabase.DefaultInstance
            .GetReference("Badges")
            .GetValueAsync()
            .ContinueWithOnMainThread((task =>
            {

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
                    
                    foreach (string b in badgeIDs)
                    {
                        GameObject newBadge = Instantiate(badgePrefab, badgeParent.transform);
                        newBadge.GetComponentInChildren<Text>().text = snapshot.Child(b).Value.ToString();
                    }

                }

            }));
        ButtonScripts b=new ButtonScripts();
        JoinButton.onClick.AddListener(() => b.JoinProject(projectData));
    }

}

