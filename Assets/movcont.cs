using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class movcont : MonoBehaviour
{
    // Start is called before the first frame update
    NewControls controls;
    public GameObject player;
    public GameObject player1;
    public GameObject spotlight1;
    public GameObject spotlight2;
    public static bool playerfirst=false;
    public static bool playersecond = true;
    movements idelkarraha;
    public GameObject global;
    movementother idelkarraha1;
    public int actionid,actionid1;
    private bool kamka=false;
    private bool kamka1 = false;
    public GameObject rewindicon;
    public static bool wingame = false;
    public GameObject cam;
   
    void Start()
    {
        controls = new NewControls();
        controls.player.Enable();
        idelkarraha = FindObjectOfType<movements>();
        idelkarraha1 = FindObjectOfType<movementother>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene active = SceneManager.GetActiveScene();
       // SceneManager.LoadScene(active.name);
        if (active.name == "Tutorial")
        {
            if (player.transform.position.x > 80f)
            {
                global.SetActive(true);
            }
        }
        if(active.name == "level1")
        {
            if (player.transform.position.x > 22f && player1.transform.position.x>22f)
            {
                movcont.wingame = true;
            }
            else
            {
                movcont.wingame = false;
            }
        }
        if (Input.GetKey(KeyCode.Q)==true)
        {
            rewindicon.SetActive(true);
        }
        else
        {
            rewindicon.SetActive(false);
        }
       
       
    
        if (controls.player.active.ReadValue<float>() == -1)
        {


            if (active.name == "Tutorial")
            {
                if (player.transform.position.x > 80f)
                {
                    cam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
                }
            }
            else
            {
                cam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
            }
            player1.GetComponent<RewindAbstract>().enabled = false;
            player1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            player.GetComponent<RewindAbstract>().enabled = true;

            player.GetComponent<movements>().enabled = true;
            player1.GetComponent<movementother>().enabled = false;
            //player1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
          //  idelkarraha1.actionid1 = 0;
            spotlight1.SetActive(true);
            spotlight2.SetActive(false);
            kamka1 = false;
        }
        if(controls.player.active.ReadValue<float>()== 1)
        {



            if (active.name == "Tutorial")
            {
                if (player.transform.position.x > 80f)
                {
                    cam.GetComponent<CinemachineVirtualCamera>().Follow = player1.transform;
                }
            }
            else
            {
                cam.GetComponent<CinemachineVirtualCamera>().Follow = player1.transform;
            }
            //  StartCoroutine(waitforseconds1());
            player.GetComponent<RewindAbstract>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            player1.GetComponent<RewindAbstract>().enabled = true;
            player.GetComponent<movements>().enabled = false;
            player1.GetComponent<movementother>().enabled = true;
            //  player.GetComponent<movements>().enabled = true;
          //  idelkarraha.actionid = 0;
            // player.GetComponent<movements>().enabled = false;
            spotlight1.SetActive(false);
            spotlight2.SetActive(true);
            kamka = false;

        }
        if (player.GetComponent<movements>().enabled == false && kamka==false)
        {
            actionid = Animator.StringToHash("action");
           // print("ravi shirsat");
            FindObjectOfType<movementother>().largeicon.SetActive(false);
            player.GetComponent<Animator>().SetInteger(actionid, 0);
            kamka = true;

        }
        if(player1.GetComponent<movementother>().enabled == false && kamka1 == false)
        {
            actionid1 = Animator.StringToHash("action1");
          //  print("ravi shirsat");
            player1.GetComponent<Animator>().SetInteger(actionid1, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            //  player1.SetActive(true);
            ///  global.SetActive(true);
            //   SceneManager.LoadScene("level1");
            wingame = true;

            //FindObjectOfType<textmanagerscipr>().dailog();




        }
        else
        {
            wingame = false;
        }
    }

}
