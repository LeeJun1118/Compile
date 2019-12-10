using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private Animator Anim;



    private void Awake()
    {
        Anim = this.gameObject.GetComponent<Animator>();
    }


    void Start()
    {
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            new Vector3(Hor * Time.deltaTime, 0, Ver * Time.deltaTime));


        Anim.SetFloat("Ver", Ver);
        Anim.SetFloat("Hor", Hor);




        /*
        //** 지면위에 플에이어가 있는지 없는지.
        if(true)
        {

        }
        else
        {

        }
         */
    }
}
