using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProject : MonoBehaviour
{
    ProjectData dataToShow;
    Text NameText;

    // Start is called before the first frame update
    void Start()
    {
       // dataToShow=new ProjectData();
        NameText = GetComponent<Text>();
       // SetName();
    }

    void SetName()
    {
        NameText.text=dataToShow.name;
    }
    public void SetProjectData(ProjectData data)
    {
        dataToShow = data;
    }
}
