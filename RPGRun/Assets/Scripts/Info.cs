using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Info : MonoBehaviour
{
    // 플레이 버튼을 누르면 SampleScene으로 이동한다.
    public void PlayBtn()
    {
        SceneManager.LoadScene("InfoScene");
    }
}
