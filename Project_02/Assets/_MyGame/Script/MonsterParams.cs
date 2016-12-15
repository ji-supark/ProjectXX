using UnityEngine;
using System.Collections;

public class MonsterParams : CharParams {

    public string name;

    public override void InitParams()
    {
        name = "Skeleton Worrior";
        maxHP = 50;
        curHP = maxHP;
        attackMin = 2;
        attackMax = 5;

        isDead = false;
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }
}
