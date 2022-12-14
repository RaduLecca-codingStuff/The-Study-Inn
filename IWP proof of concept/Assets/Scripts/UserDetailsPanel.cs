using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserDetailsPanel : MonoBehaviour
{
    public Text UserName;
    public GameObject BadgeParent;
    public GameObject BadgePrefab;

    private void OnEnable()
    {
        UserName.text = GameManager.AccountUser.Username;
        foreach(Badge badge in GameManager.AccountUser.Competences)
        {
            GameObject bdg = Instantiate(BadgePrefab);
            bdg.GetComponentInChildren<Text>().name = badge.BadgeName;
            bdg.transform.SetParent(BadgeParent.transform);
        }
        
    }
}
