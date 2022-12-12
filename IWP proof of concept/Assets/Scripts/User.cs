using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    string _username;
    string _password;
    List<Badge> _competences;
    List<string> _signedInProjects;
    int _accountType;                          
    string _accountId;
    Sprite _profilePic;
    Sprite _bannerPic;

    public User()
    {
        _accountId = "0";
        _username = "John doe";
        _password = "";
        _competences = new List<Badge>();
        _signedInProjects = new List<string>();

    }
    public User(string ID,string username,string password,List<Badge> competences,List<string>projects)
    {
        _accountId = ID;
        _username = username;
        _password = password;
        _competences = competences;
        _signedInProjects = projects;

    }

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

    void AddCompetence(Badge s)
    {
        _competences.Add(s);
    }
    void RemoveCompetence(int i)
    {
        _competences.RemoveAt(i);
    }
}
