using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onhover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    public string popanimation = "pop";
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool(popanimation, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool(popanimation, false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
