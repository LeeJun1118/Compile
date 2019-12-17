using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //카메라로부터 화면사의 좌표를 관통하는 가상의 선(레이)을 생성해서 리턴해 주는 함수
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //Physics.Raycast(래이 타입 변수, out 레이캐스트 히트 타입변수) : 
            //가상의 레이저선(래이)이 충돌체와 충돌하면, true(참) 값을 리턴하면서 동시에 레이캐스트 히트 변수에 충돌 대상의 정보를 담아 주는 함수           
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Terrain" || hit.collider.gameObject.name == "Floor1" || hit.collider.gameObject.name == "Floor2")//이렇게 하면 왜 안되는 지? 
                {
                    // player.transform.position = hit.point;

                    //마우스 클릭 지점의 좌표를 플레이어가 전달받은뒤,상태를 이동상태로 바뀜
                    player.GetComponent<PlayerFSM>().MoveTo(hit.point);
                }
                else if (hit.collider.gameObject.tag == "Enemy")//마우스 클릭한 대상이 적 캐릭터인 경우
                {
                    player.GetComponent<PlayerFSM>().AttackEnemy(hit.collider.gameObject);
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        CheckClick();
    }
}