//Jake Poshepny
//4 9 19

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> UIPanels = new List<GameObject>();
    public GameObject startPanel;

    private void Awake()
    {
        //Turn off all panels
        foreach (GameObject p in UIPanels)
        {
            p.SetActive(false);
        }

        //Turn on the default starting panel
        startPanel.SetActive(true);
    }

    //Load a Scene using a Button press
    public void BM_LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Quit the Application
    public void BM_Quit()
    {
        Application.Quit();
    }

    //Change the current UI Panel that is being viewed
    public void BM_ChangeUIPanel(GameObject newPanel)
    {
        startPanel.SetActive(false);
        startPanel = newPanel;
        startPanel.SetActive(true);
    }
}
