using UnityEngine;
using UnityEngine.Events;//유니티 시스템 이벤트를 사용하겠다는 선언.
using System.Collections;

public class CharParams : MonoBehaviour {
    public int maxHP { get; set; }
    public int curHP { get; set; }
    public int attackMax { get; set; }
    public int attackMin { get; set; }

    public bool isDead { get; set; }

    [System.NonSerialized]
    public UnityEvent deadEvent = new UnityEvent();//이벤트 설정.


    void Start () {
        InitParams();

	}

    //가상함수.
    //파라메타 초기화 함수.
    public virtual void InitParams()
    {

    }

    //공격력 계산함수.
    public int GetRandomAttack()
    {
        int rndAttack = Random.Range(attackMin, attackMax + 1);

        return rndAttack;
    }

    //공격에 데미지를 받는 함수
    public void SetEnemyAttack(int enemyAttPower)
    {
        curHP -= enemyAttPower;
        UpdateAfterReceiveAttack();
    }

    protected virtual void UpdateAfterReceiveAttack()
    {
        print("Attacked!! remain HP : " + curHP);
        if (curHP <= 0)
        {
            curHP = 0;
            isDead = true;
            print("나는죽었다");
            deadEvent.Invoke();//이벤트 발생.
        }
    }
}
