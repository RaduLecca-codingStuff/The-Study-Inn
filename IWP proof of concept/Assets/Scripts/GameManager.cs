using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _userID;
    public void LogIn(int ID)
    {
        _userID = ID;
    }
}
