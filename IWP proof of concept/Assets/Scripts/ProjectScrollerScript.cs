using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ProjectScrollerScript : MonoBehaviour
{
    List<ProjectData> projects = new List<ProjectData>();
    public GameObject optionBase;
    GameObject ScrollParent;
    public ButtonScripts bScripts;
    
    public void ReadString()
    {
        string path = Application.dataPath + "/DataFiles/test.pdata";
        Resources.Load(path);
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    private void Awake()
    {
        ScrollParent = GameObject.FindWithTag("SearchProjList");
    }
    // Start is called before the first frame update
    void Start()
    {
        ReadString();
        GameObject option;
        
        for(int i = 1; i <= 10; i++)
        {
            option = Instantiate(optionBase);
            SetButtons(option.GetComponentInChildren<Button>());
            option.transform.SetParent(ScrollParent.transform);
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetButtons(Button button)
    {
        button.onClick.AddListener(bScripts.OpenDetailsWindow);
    }
    
}
