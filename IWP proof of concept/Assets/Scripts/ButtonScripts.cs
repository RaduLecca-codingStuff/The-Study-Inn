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

    List<Button> ButtonsToDisable;

    public void OpenTestPanel(Button button)
    {
        TestPanel.SetActive(true);
    
    }
    public void CloseTestPanel()
    {

        TestPanel.SetActive(false);
    }
    public void AddButtonToDisable(Button button)
    {
        ButtonsToDisable.Add(button);
    }
    void ClearButtonsToDisable()
    {
        ButtonsToDisable.Clear();
    }
    void DisableAllButtons()
    {
        foreach(Button button in ButtonsToDisable)
        {
            button.enabled = false;
        }
    }
    void ReEnableButtons()
    {
        foreach (Button button in ButtonsToDisable)
        {
            button.enabled = true;
        }
    }

    public void OpenSearchBarProjects()
    {
        SearchbarProj.SetActive(true);
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
}
