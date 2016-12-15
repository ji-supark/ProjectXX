using UnityEngine;
using System.Collections;

public class PlayerParams : CharParams
{

    public override void InitParams()
    {
            maxHP = 100;
            curHP = maxHP;
            attackMin = 5;
            attackMax = 8;

            isDead = false;     
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
    }
}
