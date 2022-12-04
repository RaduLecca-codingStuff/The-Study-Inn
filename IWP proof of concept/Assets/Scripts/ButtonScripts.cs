using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestPanel;
    public GameObject SearchbarProj;
    public GameObject PDetailsWindow;

    List<Button> ButtonsToDisable;

    public void OpenTestPanel(Button button)
    {
        TestPanel.SetActive(true);
        //DisableAllButtons();
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
    public void OpenDetailsWindow()
    {
        PDetailsWindow.SetActive(true);
    }
    public void CloseDetailsWindow()
    {
        PDetailsWindow?.SetActive(false);
    }
}
