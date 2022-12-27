using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;


public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestPanel;
    public GameObject SearchbarProj;
    public DisplayFullProjectInfo PDetailsWindow;
    public GameObject CenterContent;

    public static ProjectData dataToDisplay;

    

    public void OpenTestPanel(Button button)
    {
        TestPanel.SetActive(true);

    }
    public void CloseTestPanel()
    {

        TestPanel.SetActive(false);
    }

    public void OpenDetailsWindow(ProjectData dt)
    {
        PDetailsWindow.SelectProject(dt);
        PDetailsWindow.gameObject.SetActive(true);
    }
    public void CloseDetailsWindow()
    {
        PDetailsWindow.gameObject.SetActive(false);
    }

    public void SwitchCenterContent(GameObject CParent)
    {
        for (int i = 0; i < CenterContent.transform.childCount; i++)
        {
            if (CenterContent.transform.GetChild(i).gameObject)
                CenterContent.transform.GetChild(i).gameObject.SetActive(false);
        }
        CParent.SetActive(true);
    }
    public void ActivatePopUp(GameObject Pparent)
    {
        Pparent.SetActive(true);
    }
    public void ClosePopUp(GameObject Pparent)
    {
        Pparent.SetActive(false);
    }
    public void TryLogIn(Text user, Text password, GameObject loginMenu, GameObject userMenu, Text ErrorMessage)
    {
        string url = GameManager.DATA_URL;
        FirebaseDatabase.DefaultInstance
            .GetReference("UserList")
            .GetValueAsync()
            .ContinueWithOnMainThread((task =>
            {

                if (task.IsCanceled)
                {
                    Debug.LogError("DATA RETRIEVAL CANCELLED");
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("USER DATA IS SOMEHOW BROKEN");
                }
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    User c;
                    foreach (var child in snapshot.Children)
                    {
                        string t = child.GetRawJsonValue();
                        c = JsonUtility.FromJson<User>(t);
                        Debug.Log(c.password);
                        if (user.text == c.username && password.text == c.password)
                        {

                            GameManager.AccountUser = c;
                            GameManager.AccountUser.accountID = child.Key;
                            userMenu.SetActive(true);
                            loginMenu.SetActive(false);
                            user.text = "";
                            password.text = "";
                            
                        }
                        else
                        {
                            ErrorMessage.text = "Incorrect username and/or password. Please try again.";
                        }
                        user.text = "";
                        password.text = "";

                    }
                }
            }
            ));
    }

    public void JoinProject(ProjectData pr)
    {
        if (GameManager.AccountUser.projectList == "")
            GameManager.AccountUser.projectList += pr.projectID;
        else
            GameManager.AccountUser.projectList += ','+ pr.projectID;


        string url = GameManager.DATA_URL;
        FirebaseDatabase.DefaultInstance
            .GetReference("UserList")
            .Child(GameManager.AccountUser.accountID)
            .Child("projectList")
            .SetValueAsync(GameManager.AccountUser.projectList);

            /*
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
                    string playerData = snapshot.GetRawJsonValue();

                    foreach (var child in snapshot.Children)
                    {
                        string t = child.GetRawJsonValue();
                        ProjectData proj = JsonUtility.FromJson<ProjectData>(t);
                        //projects.Add(proj);
                    }
                    //snapshot.Child(1).Key
                }

            }));
            */


    }
}
