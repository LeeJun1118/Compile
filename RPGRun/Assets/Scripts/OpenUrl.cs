using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string URL= "https://github.com/LeeJun1118/Compile";
    public void Open()
    {
        Application.OpenURL(URL);
    }
}
