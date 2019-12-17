using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfoScene : MonoBehaviour
{
    // 플레이 버튼을 누르면 SampleScene으로 이동한다.
    public void InfoBtn()
    {
        SceneManager.LoadScene("Information");
    }
}
