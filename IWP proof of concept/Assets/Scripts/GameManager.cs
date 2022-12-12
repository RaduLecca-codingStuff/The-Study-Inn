using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    int _userID;
    public static User AccountUser;
    static string path;
    static string[] userDataStrings;
    public static void Login(string user,string password)
    {
        path = "Assets/DataFiles/UserListFile.udata";
        //ID,username,password,project list,email,student id
        Resources.Load(path);
        StreamReader reader = new StreamReader(path);
        userDataStrings = reader.ReadToEnd().Split('~');
        reader.Close();

        for(int i = 0; i < userDataStrings.Length; i++)
        {
            string[] key = userDataStrings[i].Split('`');
            if(key.Length > 0)
            {
                if ((key[1] == user || (key[4] != null && key[4]==user)||(key[5] != null && key[5] == user)) && key[2] == password)
                {
                    //AccountUser.
                }
            }
        }

    }
}
