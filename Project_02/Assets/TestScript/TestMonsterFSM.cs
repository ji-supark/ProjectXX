using UnityEngine;
using System.Collections;

public class TestMonsterFSM : MonoBehaviour {
    MonsterParams myParams;
    PlayerParams playerParams;

    public GameObject player;
    public GameObject Item;

	void Start () {
        myParams = GetComponent<MonsterParams>();

        player = GameObject.FindWithTag("Player");
        playerParams = player.gameObject.GetComponent<PlayerParams>();

        myParams.deadEvent.AddListener(CallDeadEvent);
	}
	
	void CallDeadEvent()
    {
        print("I'm Died!!!");
        GameObject insItem = Instantiate(Item, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }

	void Update () {
        Vector3 direction = (player.transform.position - transform.position).normalized; //방향을구한다.
        direction.y = 0;
        //나와 바라볼 방향의 각도를 구한다.
        Quaternion rotation = Quaternion.LookRotation(direction);
        //바라보게 만든다.
        transform.rotation = Quaternion.Slerp(transform.rotation,
            rotation, Time.deltaTime * 120.0f);
	}
}
