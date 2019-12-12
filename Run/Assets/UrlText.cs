using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlText : MonoBehaviour
{
    string url = "https://github.com/LeeJun1118/Compile";
    public void UrlBtn()
    {
        Application.OpenURL(url);
     
    }
}
