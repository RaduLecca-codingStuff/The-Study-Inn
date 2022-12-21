using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    public string badgeList;
    public string email;
    public string password;
    public string studentID;
    public string username;

    public User(string ID,string u,string p, string e,string b)
    {

        username = u;
        password = p;
        studentID = ID;
        email = e;
        badgeList = b;
    }

    

}
