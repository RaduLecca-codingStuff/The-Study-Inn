using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    string username;
    string password;
    string email;
    string studentID;
    string badgeList;

    List<Badge> _competences;
    List<string> _signedInProjects;                         
    string _accountId;


    public User()
    {
        _accountId = "0";
        username = "John doe";
        password = "";
        _competences = new List<Badge>();
        _signedInProjects = new List<string>();

    }
    public User(string ID,string u,string p,List<Badge> competences,List<string>projects)
    {
        _accountId = ID;
        username = u;
        password = p;
        _competences = competences;
        _signedInProjects = projects;

    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    public List<Badge> Competences
    {
        get { return _competences; }
        set { _competences = value; }
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
