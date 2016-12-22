using UnityEngine;
using System.Collections;

public class TestPlayerFSM : MonoBehaviour {
    PlayerParams myParams;
    MonsterParams enemyParams;

    public GameObject enemy;

	void Start () {
        myParams = GetComponent<PlayerParams>();
        myParams.InitParams();

        enemy = GameObject.FindWithTag("Enemy");

        enemyParams = enemy.GetComponent<MonsterParams>();
	}

	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            int attackPower = myParams.GetRandomAttack();
            enemyParams.SetEnemyAttack(attackPower);
        }
	}
}
