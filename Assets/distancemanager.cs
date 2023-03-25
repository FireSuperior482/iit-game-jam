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

    void Start()
    {
        vol = GetComponent<Volume>();
        inidist = Mathf.Abs(player.transform.position.x - player1.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs(player.transform.position.x - player1.transform.position.x) - inidist - startoffset;

        if (dist > 0)
        {
            if (dist > maxdistance)
                Debug.Log("death");
            vol.weight = dist / maxdistance;
        }
        else
            vol.weight = 0;
    }
}
