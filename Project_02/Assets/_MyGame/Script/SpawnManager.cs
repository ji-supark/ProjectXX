using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public Transform[] spawnpoints; // 생성포인트를 담을 변수.
    public GameObject[] monsters; // 몬스터를 담을 변수.
	
	void Start () {
	    for (int i = 0; i <= spawnpoints.Length -1; i++)
        {
            int j = Random.Range(0, monsters.Length - 1);

            GameObject insMon = Instantiate(monsters[j], spawnpoints[i].position,
                Quaternion.identity) as GameObject; //생성포인트에 몬스터 생성.
        }
	}
	
}
