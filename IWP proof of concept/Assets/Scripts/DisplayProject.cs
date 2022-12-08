using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProject : MonoBehaviour
{
    ProjectData dataToShow;
    public Text NameText;

    // Start is called before the first frame update
    public void SetProjectData(ProjectData data)
    {
        dataToShow = data;
        if(NameText != null)
        NameText.text = dataToShow.name;
    }
    public ProjectData SendData()
    {
        return dataToShow;
    }
}
