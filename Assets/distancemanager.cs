using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class distancemanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private Transform player1;
    public float maxdistance = 20.0f;
    public float startoffset = 5.0f;
    Volume vol;
    float inidist;
    public static bool dead;
    public AudioSource sour;
    private bool timepass=false;
    void Start()
    {
        vol = GetComponent<Volume>();
        
        inidist = Mathf.Abs(player.transform.position.x - player1.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
       print(dead);
        float dist = Mathf.Abs(player.transform.position.x - player1.transform.position.x) - inidist - startoffset;

        if (dist > 0)
        {
            if (dist > maxdistance)
            {
                dead = true;
                
            }
            else
            {
               // dead = false;
                vol.weight = dist / maxdistance;
            }
        }
        else
            vol.weight = 0;


        if (vol.weight > 0.2 && !sour.isPlaying && timepass==false)
        {
            // Sound s = Array.Find(sounds, sound => sound.name == "theam");
            // s.volume = 0.1f;
            //FindObjectOfType<audio_manager>().play("heartbeat");
           // if (vol.weight > 0.2)
            {
                FindObjectOfType<audio_manager>().play("heartbeat");
              
            }
            // if (!source.isPlaying && cycle)
            // {
            //     FindObjectOfType<audio_manager>().play("heartbeat");
            //     cycle = false;
            //     cycle2 = true;
            //
            // }
            // if (!source.isPlaying && cycle2)
            // {
            //     FindObjectOfType<audio_manager>().play("no sound",2*vol.weight+0.2f);
            //     cycle = true;
            //     cycle2 = false;
            //
            // }


        }
        if (vol.weight < 0.2)
        {
            timepass = true;
        }
    }
}
