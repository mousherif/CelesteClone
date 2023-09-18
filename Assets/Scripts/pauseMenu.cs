using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausemenu.activeSelf)
            {
                Time.timeScale = 0f;
                Pausemenu.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                Pausemenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
    public void quit()
    {
        Application.Quit();
    }

    public void resume()
    {
        Time.timeScale = 1f;
        Pausemenu.SetActive(false);
        Cursor.visible = false;
    }
}
