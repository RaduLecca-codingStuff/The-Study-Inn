using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestPanel;
    public GameObject SearchbarProj;
    public DisplayFullProjectInfo PDetailsWindow;
    public GameObject CenterContent;

    public static ProjectData dataToDisplay;

    public void OpenTestPanel(Button button)
    {
        TestPanel.SetActive(true);
    
    }
    public void CloseTestPanel()
    {

        TestPanel.SetActive(false);
    }

    public void OpenDetailsWindow(ProjectData dt)
    {
        PDetailsWindow.SelectProject(dt);
        PDetailsWindow.gameObject.SetActive(true);
    }
    public void CloseDetailsWindow()
    {
        PDetailsWindow.gameObject.SetActive(false);
    }

    public void SwitchCenterContent(GameObject CParent)
    {
        for(int i = 0; i < CenterContent.transform.childCount; i++)
        {
            if (CenterContent.transform.GetChild(i).gameObject)
                CenterContent.transform.GetChild(i).gameObject.SetActive(false);
        }
        CParent.SetActive(true);
    }
    public void ActivatePopUp(GameObject Pparent)
    {
        Pparent.SetActive(true);
    }
    public void ClosePopUp(GameObject Pparent)
    {
        Pparent.SetActive(false);
    }
}
