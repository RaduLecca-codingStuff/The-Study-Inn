using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using System.IO;
using UnityEngine.UI;

public class LogInScreen : MonoBehaviour
{
    public Text user;
    public Text password;
    public Text errorText;
    public GameObject UserMenu;
    public Button loginButton;
    public GameObject RegisterButton;
    public GameObject ForgotPasswordButton;
    public ButtonScripts ButtonScripts;
    
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(() => ButtonScripts.TryLogIn(user, password, this.gameObject, UserMenu, errorText));
    }

}
