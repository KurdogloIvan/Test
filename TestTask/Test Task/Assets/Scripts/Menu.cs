using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private ControllerScript _control;
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        _control = GameObject.FindObjectOfType<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuPanel.SetActive(true);
            _control.enabled = false;
        }  
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void EnableController()
    {
        _control.enabled = true;
    }
}
