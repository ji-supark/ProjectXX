using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterParams : CharParams {

    public string name;

    // private GameObject hpBar;
    public Image imageHpBar;

    public override void InitParams()
    {
        name = "Skeleton Worrior";
        maxHP = 50;
        curHP = maxHP;
        attackMin = 2;
        attackMax = 5;

        isDead = false;
    }

    void InitHpBar()
    {
        // hpBar.transform.localScale = new Vector3(1f,1f,1f);
        imageHpBar.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    protected override void UpdateAfterReceiveAttack()
    {
        base.UpdateAfterReceiveAttack();
        imageHpBar.rectTransform.localScale =
            new Vector3((float)curHP / (float)maxHP, 1f, 1f);
    }
}
