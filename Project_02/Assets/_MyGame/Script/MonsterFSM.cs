using UnityEngine;
using System.Collections;

public class MonsterFSM : MonoBehaviour {
    public enum monsterStatus {Idle, Move, Chasing, Attack, Die}
    public monsterStatus currentStatus;

    public Animator anim;
    public NavMeshAgent agent;
    public GameObject Player;

    public float monStopDistance = 1.0f; //최소 정지거리.
    public float monChasingRange = 5.0f; //player를 추적하는 최대 감지거리.
    public float monAttackRange = 2.0f; //공격 최대 거리.

    public Vector3 monBasePoint; //몬스터의 최초 생성 위치.
    public Vector3 monDestination; //몬스터의 목적지.
    public float monRndPointRange = 5.0f; //랜덤 포인트 생성 범위.
    public float waitTime = 2.0f; //대기시간.
    public float cureentTime; //누적시간.
    public float distancePlayerMonster; //플레이어와 몬스터의 거리.


    void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        Player = GameObject.FindGameObjectWithTag("Player");

        monBasePoint = transform.position; //몬스터 생성 위치 등록.
        monDestination = agent.destination; //navmashagent 목적지 초기화.

        ChangeStatus(monsterStatus.Idle);
	}
	
	void Update () {
        CheckPlayerPosition();
        UpdateStatus();
	}

    //몬스터의 상태 변경 함수.
    void ChangeStatus(monsterStatus newStatus) //몬스터의 스테이터스 변경 함수.
    {
        if (currentStatus == newStatus) //기존의 상태와 새로운 상태가 같다면 함수 빠져나감.
            return; //함수빠져나감.
        currentStatus = newStatus;
        UpdateStatus(); //상태 갱신 함수 호출.
    }
    //몬스터의 상태를 갱신하는 함수.
    void UpdateStatus()
    {
         switch (currentStatus)
        {
            case monsterStatus.Idle:
                IdleStat();
                break;
            case monsterStatus.Move:
                MoveStat();
                break;
            case monsterStatus.Chasing:
                ChasingStat();
                break;
            case monsterStatus.Attack:
                AttackStat();
                break;
            case monsterStatus.Die:
                print("DIE!");
                break;
                
        }
    }
    //몬스터 상태에 따른 처리 함수.
    void IdleStat()
    {
        if (distancePlayerMonster > monChasingRange)//플레이어가 chasing 범위 밖에 있을때.
        {
            cureentTime += Time.deltaTime; //대기 시간 누적.
            anim.SetFloat("Speed", 0.0f); //이동속도 제거.
            anim.SetBool("Attack", false); //공격 상태 해제.

            if (cureentTime >= waitTime) //대기시간이 충족이 되면.
            {
                MakeRandomPoint(); //이동 포인트 생성.
                if (Vector3.Distance(monDestination, transform.position) > monStopDistance)
                {
                    cureentTime = 0.0f; //누적시간 초기화.
                    ChangeStatus(monsterStatus.Move); //이동으로 상태변환.
                }
            }
        }
        else //플레이어 chasing 번위에 안에 있을때.
            ChangeStatus(monsterStatus.Chasing);
    }
    void MoveStat()
    {
        agent.destination = monDestination; //목적지 설정.

        if (agent.remainingDistance <= monStopDistance) //목적지까지의 남은 거리가 monStopDistance보다 적으면.
            ChangeStatus(monsterStatus.Idle); //상태변환.

        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetBool("Attack", false);
    }
    void ChasingStat()
    {
        agent.destination = Player.transform.position; //목적지를 플레이어의 위치로 등록.

        if(distancePlayerMonster >= monChasingRange) //chasing거리를 벗어나면.
        {
            monDestination = monBasePoint; //목적지를 최초 생성 포인트로 전환.
            ChangeStatus(monsterStatus.Move); 
        }
        if (distancePlayerMonster <= monAttackRange) //추적중 공격 번위에 플레이어가 들어오면.
            ChangeStatus(monsterStatus.Attack);
        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetBool("Attack", false);

    }
    void AttackStat()
    {
        if (distancePlayerMonster > monAttackRange) //플레이어가 공격범위를 벗어났다면.
            ChangeStatus(monsterStatus.Chasing);
        else
        {
            agent.destination = transform.position; //제자리 멈춤.
            anim.SetFloat("Speed", 0.0f);
            anim.SetBool("Attack", true);
        }
    }
    //몬스터가 이동할 랜덤 포인터 생성 함수 및 캐릭터 위치 파악 함수.
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 rndPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(rndPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    void MakeRandomPoint()
    {
        Vector3 point;
        if (RandomPoint(monBasePoint, monRndPointRange, out point))
            monDestination = point; // 몬스터의 목적지에 생성된 포인트 등록.
    }
    void CheckPlayerPosition()
    {
        distancePlayerMonster = Vector3.Distance(Player.transform.position, transform.position);
    }
}
