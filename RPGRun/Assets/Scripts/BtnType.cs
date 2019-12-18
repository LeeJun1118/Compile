using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    bool isSound;

    public AudioSource m_AudioSource;

    public void Start()
    {
        defaultScale = buttonScale.localScale;
        isSound = true;


        //** 사운드가 들어가있는 오브젝트에서 해당 사운드의 컴퍼넌트를 들고옴. 
        m_AudioSource = GameObject.Find("Pillar").GetComponent<AudioSource>();

        //** 볼륨조절   (0.0f ~ 1.0f)
        m_AudioSource.volume = 1.0f;

        //** 반복 재생
        m_AudioSource.loop = true;

        //** 활성화시 해당씬 실행시 바로 사운드 재생이 시작됩니다.
        //** 비활성화시 Play()명령을 통해서만 재생됩니다.
        m_AudioSource.playOnAwake = true;

        //** 씬안에 모든 오디오 소스중 현재 오디오 소스의 우선순위를 정한다.
        //** 0 : 최우선
        //** 128 : 기본값
        //** 256 : 최하

        m_AudioSource.priority = 0;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneLoad.LoadSceneHandle("SampleScene", 0);
                break;

            case BTNType.Continue:
                SceneLoad.LoadSceneHandle("InfoScene", 1);

                break;

            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;

            case BTNType.Sound:
                {
                    if (isSound)
                    {
                        Debug.Log("사운드OFF");
                        m_AudioSource.Stop();
                    }
                    else
                    {
                        m_AudioSource.Play();
                        Debug.Log("사운드ON");
                    }
                    isSound = !isSound;
                }
                break;

            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;

            case BTNType.Quit:
                Application.Quit();
                Debug.Log("앱종료");
                break;
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
