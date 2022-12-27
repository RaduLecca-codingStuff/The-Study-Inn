using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserProjectList : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parentObj;
    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateProjList();
    }
    public void UpdateProjList()
    {
        string[] projectIDS=GameManager.AccountUser.projectList.Split(',');

        if(projectIDS.Length != 0)
            foreach (string projectID in projectIDS)
            {
                GameObject proj = Instantiate(prefab);
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
                       proj.GetComponentInChildren<Text>().text = snapshot.Child(projectID).Key;
                   }
               }
               ));
                proj.transform.SetParent(parentObj.transform);
            }
        


    }
}
