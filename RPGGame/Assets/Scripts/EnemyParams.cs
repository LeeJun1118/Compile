using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //유니티 UI 를 생성 할때 추가하는 네임 스페이스


public class EnemyParams : CharacterParams
{
    public string name;
    public int exp { get; set; }
    public int rewardMoney { get; set; }
    public Image hpBar;


    public override void InitParams()
    {
        name = "Monster";
        level = 1;
        maxHp = 80;
        curHp = maxHp;
        attackMin = 2;
        attackMax = 5;
        defense = 1;

        exp = 10;
        rewardMoney = Random.Range(10, 31);

        InitHpBarSize();
    }

    void InitHpBarSize()
    {
        //hpBar 의 사이즈를 원래 자신의 사이즈 ,1배의 사이즈로 초기와시켜 주게 됨
        hpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();

        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }
}