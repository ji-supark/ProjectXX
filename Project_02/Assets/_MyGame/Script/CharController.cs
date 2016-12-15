using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour
{
    public NavMeshAgent agent; //navmeshagent 저장 변수.
    public Animator anim; //메카님용 animatior 저장 변수

    PlayerParams myParams;
    MonsterParams monParams;

    public GameObject clickEffect;

    public Vector3 destination; //목적지를 저장할 변수.


    void Start()
    {
        //component 변수에 할당. 
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        myParams = GetComponent<PlayerParams>(); //파라메타 할당.
        myParams.InitParams(); //초기값 설정 함수 콜.

        //목적지 초기화.
        destination = agent.destination;
    }//start

    void Update()
    {
        //마우스왼쪽버튼 누르기
        if (Input.GetMouseButtonDown(0))
        {
            MakeClickPoint();
        }

        //설정된 목적지와 나와의 거리가 최소 이동거리보다 큰지 판단.
        if (Vector3.Distance(destination, transform.position) > 1.0f)
        {
            agent.destination = destination; //이동.
        }

        //속도의 길이를 판단해서 애니메이션의 상태를 변환시킨다.
        if (agent.velocity.magnitude > 0.1f) // idle -> run
            anim.SetFloat("Speed", agent.velocity.magnitude);
        else
            anim.SetFloat("Speed", 0.0f); // run -> idle

        //attack 구현(키 조합).
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            //제자리에 멈춤.
            agent.destination = transform.position;
            destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //공격 동작 실행.
            anim.SetBool("IsAttack", true);
        }
        else
            anim.SetBool("IsAttack", false);

    }//update

    void MakeClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //광선을 만든다.
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 9))
        {
            //목적지 클릭지점으로 생성.
            destination = new Vector3(hit.point.x,
                hit.point.y, hit.point.z);

            //해당지점에 클릭이펙트 생성.
            GameObject insClickEffect = Instantiate(clickEffect,
                hit.point, Quaternion.identity) as GameObject;
            Destroy(insClickEffect, 1.0f);
        }
    }

    public void AttackCal() //공격 이벤트 함수.
    {
        int attackPower = myParams.GetRandomAttack(); //공격력 계산.
        monParams.SetEnemyAttack(attackPower); //공격력을 몬스터 전달.
    }

    public void AttackEnemy(GameObject enemy)
    {
        monParams = enemy.GetComponent<MonsterParams>();
        if (monParams.isDead = false)
        {

        }
        else
        monParams = null;
    }


}
