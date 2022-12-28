using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogOut : MonoBehaviour
{
    ButtonScripts scr;
    public GameObject LoginMenu, UserMenu;
    public UserMetricData u;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => scr.Logout(LoginMenu, UserMenu, u));
    }
}
