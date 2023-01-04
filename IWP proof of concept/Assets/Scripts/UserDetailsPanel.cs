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
                    foreach (string badge in badges)
                    {
                        GameObject bdg = BadgePrefab;
                        bdg.GetComponentInChildren<Text>().name = snapshot.Child(badge).Value.ToString();
                        Instantiate(bdg, BadgeParent);
                    }
                    

                }
            }
            ));
            }

}
