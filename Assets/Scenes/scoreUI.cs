using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    public TextMeshProUGUI fruits;
    //  public TextMeshProUGUI foodhai;
   // movements food;

    // Start is called before the first frame update
    void Start()
    {
       // food = FindObjectOfType<movements>();
    }

    // Update is called once per frame
    void Update()
    {
        fruits.text = "X" + movements.totalapples.ToString();
        /// foodhai.text = food.x.ToString();   
    }
}