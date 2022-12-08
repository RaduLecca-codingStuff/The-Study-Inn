using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    string _username;
    string _password;
    List<string> _competences;
    List<string> _signedInProjects;
    int _accountType;                          
    int _accountId;
    Sprite _profilePic;
    Sprite _bannerPic;


    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    void SetBanner( Sprite s)
    {
        _bannerPic = s;
    }

    void SetProfile(Sprite s)
    {
        _profilePic = s;
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
