using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class textmanagerscipr: MonoBehaviour

{

    public TextMeshPro textDisplay;
    //public TextMeshPro textDisPlay1;
    public string[] sentences;
    public StringBuilder a;
    private int index;
    public float typingspeed;
    WaitForSeconds time;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    //  public GameObject continueButton;
    //public Transform player;
    // Start is called before the first frame update
    public void Start()
    {
        time = new WaitForSeconds(typingspeed);
        a = new StringBuilder(50);
       
    }
    public void dailog()
    {
        StartCoroutine(Type());
    }
  
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            a.Append(letter);
            //textDisplay.text += letter;

            yield return time;
            textDisplay.text = a.ToString();
        }
        a.Clear();
    }
    
    public void Nextsentence()
    {   // continueButton.SetActive(false); 
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            
        }
        else
        {
            textDisplay.text = "";
        }
    }

    // Update is called once per frame

}
