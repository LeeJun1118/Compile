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
        // Esc키를 누르면
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //게임이 일시정지 되면서 메뉴창이 뜬다.
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
                Time.timeScale = 1f;
            }
        }
    }


}
