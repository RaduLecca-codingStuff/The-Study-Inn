using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProject : MonoBehaviour
{
    ProjectData dataToShow;
    Text NameText;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void SetProjectData(ProjectData data)
    {
        NameText = GetComponent<Text>();
        dataToShow = data;
        if(NameText != null)
        NameText.text = dataToShow.name;
    }
}
