using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pausemenu1;
    public GameObject endmenu;
    public GameObject deathmenu;
     public GameObject global;
    // Start is called before the first frame update
    void Start()
    {
       // deathmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && endmenu.activeInHierarchy==false && deathmenu.activeInHierarchy==false)
        {
            pausegame();
        }
        if (pausemenu1.activeInHierarchy == false && deathmenu.activeInHierarchy == false)
        {
            if(movcont.wingame == true)
            {
                Time.timeScale = 0f;
                endmenu.SetActive(true);
            }
        }
        if(pausemenu1.activeInHierarchy == false && endmenu.activeInHierarchy == false)
        {
            if(distancemanager.dead == true)
            {
                Time.timeScale = 0f;
              //  global.SetActive(false);
                deathmenu.SetActive(true);
            }
        }
        
        
    }
    public void pausegame()
    {
        Time.timeScale = 0f;
        pausemenu1.SetActive(true);
    }
    public void resumegame()
    {
        Time.timeScale = 1f;
        pausemenu1.SetActive(false);
    }
    public void home()
    {
        Time.timeScale = 1f;
        deathmenu.SetActive(false);
        distancemanager.dead = false;
        SceneManager.LoadScene("mainmenu");
        
    }
    public void restart()
    {
        Time.timeScale = 1f;
        deathmenu.SetActive(false);

        
        distancemanager.dead = false;
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
        if (active.name == "Tutorial")
        {
            global.SetActive(false);
        }


    }

    public void continue1()
    {
        endmenu.SetActive(false);
        movcont.wingame = false;
        SceneManager.LoadScene("level1");
    }
}
