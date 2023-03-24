using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcoll : MonoBehaviour
{

    bool tempisgrounded1 = false;
    int nframes = 0;
    // DragDrop activate1;

    public Rigidbody2D rbd;
    private void LateUpdate()
    {


    }
    private void Start()
    {
        // activate1 = FindObjectOfType<DragDrop>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        /* if(activate1.absorbenergybool == true)
          { //print( rbd.mass * Mathf.Sqrt(rbd.velocity.x*rbd.velocity.x+ rbd.velocity.y*rbd.velocity.y));
              print(rbd.velocity);
              energysystem.kineticenergy += 0.5*rbd.mass*Mathf.Sqrt(rbd.velocity.x*rbd.velocity.x + rbd.velocity.y*rbd.velocity.y);
             // energysystem.kineticenergy += 0.5 * rbd.mass * (rbd.velocity.magnitude) * (rbd.velocity.magnitude);

             // print("ravi bhau");
              rbd.velocity = new Vector2(0f, 0f);
              activate1.absorbenergybool = false;
          }*/
        // else if (activate1.absorbenergybool==true)
        // {
        //     rbd.velocity = new Vector2(0f, 0f);
        // }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // landinghight = transform.position.y;
        //  healthdamage();
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Player"))
        {



            //     print("ravi shirsat purushottam");               //movements.isgrounded = true;





            tempisgrounded1 = true;

        }
        else
        {
            tempisgrounded1 = false;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            nframes++;


        }
        else
        {
            nframes = 0;

        }


        if (nframes >= 20)
        {
            movementother.isgrounded1 = true;
            movementother.isfalling1 = false;

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //  jumphight = transform.position.y;
        if (tempisgrounded1 == true)
        {
            if (collision.gameObject.CompareTag("ground"))
            {

                movementother.isgrounded1 = false;
                tempisgrounded1 = false;
            }
        }
    }

}
