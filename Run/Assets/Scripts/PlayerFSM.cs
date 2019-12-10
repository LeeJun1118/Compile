using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        AttackWait,
        Dead
    }

    public State currentState = State.Idle;

    //마우스 클릭 지점, 플레이어가 이동할 목적지의 좌표를 저장할 예정
    Vector3 curTargetPos;
    //1초에 플레이어의 방향을 360도 회전한다.
    public float rotAnglePerSecone = 360f;
    //초당 2미터의 속도로 이동
    public float moveSpeed = 2f;

    PlayerAni myAni;

    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
    }
    void ChangeState(State newState,int aniNumber)
    {
        if(currentState == newState)
        {
            return;
        }
        myAni.ChangeAni(aniNumber);
        currentState = newState;
    }

    // Update is called once per frame
    void UpdateState()
    {
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Move:
                TurnToDestination();
                MoveToDestination();
                break;
            case State.Attack:
                break;
            case State.AttackWait:
                break;
            case State.Dead:
                break;
            default:
                break;
        }

    }

    public void MoveTo(Vector3 tPos)
    {
        curTargetPos = tPos;
        ChangeState(State.Move, PlayerAni.ANI_WALK);
    }

    void TurnToDestination()
    {
        //Quaternion lookRotation(회전할 목표 방향) : 목표 방향은 목적지 위치에서 자신의 위치를 빼면 구함
        Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecone);

    }
    void MoveToDestination()
    {
        //Vector3.MoveTowards(시작지점, 목표지점, 최대 이동거리)
        transform.position = Vector3.MoveTowards(transform.position, curTargetPos, moveSpeed * Time.deltaTime);
        
        //플레이어의 위치와 목표지점의 위치가 같으면, 상태를 idle상태로 바꾸라는 명령
        if(transform.position == curTargetPos)
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }

    void Update()
    {
        UpdateState();
    }
}
