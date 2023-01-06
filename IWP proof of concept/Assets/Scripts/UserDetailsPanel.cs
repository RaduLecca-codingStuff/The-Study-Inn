using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDetailsPanel : MonoBehaviour
{
    public Text UserName;
    public RectTransform BadgeParent;
    public GameObject BadgePrefab;
    

    private void OnEnable()
    {
        UserName.text = GameManager.AccountUser.username;
        
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
                    Debug.LogError("USER DATA IS SOMEHOW BROKEN");
                }
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    string[] badges = GameManager.AccountUser.badgeList.Split(',');
                    for(int i=0;i<badges.Length;i++)
                    {
                        GameObject bdg = Instantiate(BadgePrefab, BadgeParent);
                        string value = snapshot.Child(badges[i]).Value.ToString();
                        bdg.transform.GetChild(0).GetComponent<Text>().text = value;
                    }
                    

                }
            }
            ));
            }

}
