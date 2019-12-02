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
public class MenuUI : MonoBehaviour
{
    public GameObject parts;

    public void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            if (!GameManager.isPause)
            {
                GameManager.isPause = true;
                parts.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                GameManager.isPause = false;
                parts.SetActive(false);
                Time.timeScale = 0f;
            }
        }



    }


}
