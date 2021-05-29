using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject HowTOPanel;
    //public GameObject MenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Tab))
        //{
        //    MenuPanel.SetActive(true);
        //}
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Inst()
    {
        HowTOPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Close()
    {
        HowTOPanel.SetActive(false);
    }
    //public void ResumEGame()
    //{
    //    MenuPanel.SetActive(false);
    //}
}
