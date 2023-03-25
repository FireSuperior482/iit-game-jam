using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movementother : MonoBehaviour
{
    NewControls controls;
    public float moveforce = 5f;
    private float movementx;
    private Rigidbody2D rb;
    private Animator anim;
    public float sizefactor;
    
    public float force;
   
    public float jumpforce = 12f;
    public static bool isgrounded1 = true;
    [SerializeField]
    private SpriteRenderer sr;
  

    public bool m_facingright = true;
    int action1;
    public static bool isjumping1 = false;
    public static bool isfalling1 = false;
    public int actionid1, isfallingid1;
    Vector3 originalsize;
   
    ABILITYUSE ability;
    public static bool condition=false; 
    public Transform button;
    public int totalapples = 0;
   public Animator anim1;
    public GameObject largeicon;
  
    void Start()
    {
     
        controls = new NewControls();
        controls.player.Enable();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        action1 = 0;
        //Application.targetFrameRate = 60;
        actionid1 = Animator.StringToHash("action1");
        isfallingid1 = Animator.StringToHash("isfalling1");
        //  lines = FindObjectOfType<gismo1>();
        originalsize = transform.localScale;
        ability = FindObjectOfType<ABILITYUSE>();

    }


    void Update()
    {
        // print(leftrightjumpcheck);
       // if (movcont.playersecond==false)
        {
            input();
        }
        if (controls.player.size.ReadValue<float>() == 1 && condition == false)
        {
            transform.localScale += new Vector3(Time.deltaTime*sizefactor, Time.deltaTime*sizefactor, 0);
            ability.CurrentHealth -= Time.deltaTime * ABILITYUSE.newFactor;
            largeicon.SetActive(true);
        }
        else
        {
          transform.localScale -= new Vector3(Time.deltaTime * sizefactor, Time.deltaTime * sizefactor, 0);
            largeicon.SetActive(false);
        }
        /*if(transform.localScale.x > originalsize.x)
        {
            transform.localScale -= new Vector3(Time.deltaTime * sizefactor, Time.deltaTime * sizefactor, 0);
        }*/
        if(transform.localScale.x < originalsize.x)
        {
            transform.localScale = originalsize;
        }
        //float test = controls.player.movements.ReadValue<float>();
        // print(test);
    }

    private void FixedUpdate()
    {
        action1 = 0;

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
        anim.SetInteger(actionid1, action1);
        anim.SetBool(isfallingid1, isfalling1);

      


    }

    void input()
    {

        movementx = controls.player.movements1.ReadValue<float>();
        //  if (movementx != 0)

        if (controls.player.jump1.WasPerformedThisFrame() && isgrounded1)
        {
            isgrounded1 = false;
            isjumping1 = true;
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
            action1 = 1;
            transform.right = new Vector3(movementx, 0, 0);

            //   energysystem.intenergy -= 0.1f;
        }
        Vector3 movement = new Vector3(movementx, 0f, 0f);

        transform.position += movement * Time.deltaTime * moveforce;
    }

    void playerjump()
    {

        if (isjumping1 == true)
        {
            action1 = 2;
            if (isgrounded1 == true)
                isjumping1 = false;
        }

    }

    void playerfalling()
    {
        if (isjumping1 == false && isgrounded1 == false)
        {
            isfalling1 = true;
            action1 = 2;
        }
        else
            isfalling1 = false;


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
    }

