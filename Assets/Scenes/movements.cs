using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movements : MonoBehaviour
{
    NewControls controls;
    public float moveforce = 5f;
    private float movementx;
    private Rigidbody2D rb;
    private Animator anim;
   // public GameObject pausemenu;
    public float jumpforce = 12f;
    public static bool isgrounded = true;
    [SerializeField]
    private SpriteRenderer sr;
    public List<GameObject> fruits;
    public static int totalapples = 0;
    public Transform button;
    private GameObject x;
    private bool iscollision = false;
    // gismo1 lines;
    //  public GameObject linerend;

    public bool m_facingright = true;
    public int action;
    public static bool isjumping = false;
    public static bool isfalling = false;
    public int actionid, isfallingid;
    // RewindByKeyPress rewind;
    public AudioClip collsound, stabsound;
    AudioSource asur;
    public float force;
    // WaitForSeconds deathdelay = new WaitForSeconds(1f);
    // public static bool leftrightjumpcheck = false;




    void Start()
    {
        //rewind = FindObjectOfType<RewindByKeyPress>();
        controls = new NewControls();
        controls.player.Enable();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        action = 0;
        Application.targetFrameRate = 60;
        actionid = Animator.StringToHash("action");
        asur = FindObjectOfType<AudioSource>();
        isfallingid = Animator.StringToHash("isfalling");
      //  lines = FindObjectOfType<gismo1>();


    }


    void Update()
    {
        // print(leftrightjumpcheck);
      //  if (movcont.playerfirst == false)
        {
            input();
        }
       
        //float test = controls.player.movements.ReadValue<float>();
        // print(test);
    }

    private void FixedUpdate()
    {
        action = 0;

        playermovement();
        playerjump();
        playerfalling();
     //   deathanimation();
      /*  if ((movementx < 0 && m_facingright))
        {
            playerflip();
        }
        else if ((movementx > 0 && !m_facingright))
        {
            playerflip();
        }
        if (rewind.isRewinding == true && m_facingright == false)
        {
            playerflip();
        }
        */
        anim.SetInteger(actionid, action);
        anim.SetBool(isfallingid, isfalling);
        if (iscollision == true)
        {
            if (fruits.Count != 0)
            {
                for (int i = 0; i < fruits.Count; i++)
                {
                    Vector3 directionofmove = (button.position - fruits[i].transform.position).normalized;
                    fruits[i].transform.position += directionofmove * Time.deltaTime * force;
                    if ((button.position - fruits[i].transform.position).magnitude <= 2f)
                    {
                       // anim.SetBool(appleanim, true);
                        //StartCoroutine(appleanimationhai());
                        Destroy(fruits[i]);
                        totalapples++;
                        fruits.Remove(fruits[i]);

                    }

                }

            }
            if (fruits.Count == 0)
            {
                iscollision = false;
            }

        }



    }

    void input()
    {
      
          movementx = controls.player.movements.ReadValue<float>();
      //  if (movementx != 0)
         
        if (controls.player.jump.WasPerformedThisFrame() && isgrounded)
        {
            isgrounded = false;
            isjumping = true;
            //rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpforce;
            //energysystem.intenergy -= 5.0f;
        }

    }

    void playermovement()
    {

        // movement.x = Input.GetAxisRaw("Horizontal"); for top down game
        //rb.velocity= movement*moveforce;
        // movementx = Input.GetAxisRaw("Horizontal");

        if (movementx != 0)
        {
            action = 1;
            transform.right = new Vector3(movementx, 0, 0);

            //   energysystem.intenergy -= 0.1f;
        }
        Vector3 movement = new Vector3(movementx, 0f, 0f);

        transform.position += movement * Time.deltaTime * moveforce;
    }

    void playerjump()
    {

        if (isjumping == true)
        {
            action = 2;
            if (isgrounded == true)
                isjumping = false;
        }

    }

    void playerfalling()
    {
        if (isjumping == false && isgrounded == false)
        {
            isfalling = true;
            action = 2;
        }
        else
            isfalling = false;


    }

    public void playerflip()
    {
        {
            // Debug.Log("ravi");
            m_facingright = !m_facingright;
            transform.Rotate(0f, -180f, 0f);
            //  CreateDust();
        }
    }
    //  IEnumerator deathanimation1()
    // {
    //     yield return deathdelay;
    //     Time.timeScale = 0f;
    //      pausemenu.SetActive(true);
    //  }
    /* public void deathanimation()
     {
         if (energysystem.intenergy < 0)
         {
             action = 3;
             StartCoroutine(deathanimation1());
         }
     }
    */
    /*  public void check()
      {
          leftrightjumpcheck = true;
      }
      public void checkend()
      {
          leftrightjumpcheck = false;
      }

    */
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apples"))
        {
            iscollision = true;

            x = collision.gameObject;


            fruits.Add(x);

            x.GetComponent<CircleCollider2D>().enabled = false;
            asur.PlayOneShot(collsound);

        }
    }
}

