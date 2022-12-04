using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    string _username;
    List<string> _competences;
    List<string> _signedInProjects;
    int _accountType;                          
    int _accountId;
    Sprite _profilePic;
    Sprite _bannerPic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBanner( Sprite s)
    {
        _bannerPic = s;
    }

    void SetProfile(Sprite s)
    {
        _profilePic = s;
    }

    void SetUserName(string s)
    {
        _username = s;
    }

    void AddCompetence(string s)
    {
        _competences.Add(s);
    }
    void RemoveCompetence(int i)
    {
        _competences.RemoveAt(i);
    }
}
