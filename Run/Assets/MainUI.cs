using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTNType
{
    New,
    Continue,
    Option,
    Sound,
    Back,
    Quit
}
public class MainUI : MonoBehaviour
{
    private bool showMenu;
    public GameObject parts;

    public void Start()
    {
        showMenu = false;
    }
    public void Update()
    {
        if (showMenu == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                parts.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                parts.SetActive(false);
            }
        }
        
    }


}
