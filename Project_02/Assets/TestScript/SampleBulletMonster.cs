using UnityEngine;
using System.Collections;

public class SampleBulletMonster : MonoBehaviour{
    public int power = 10; //총알의 공격력.

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.SendMessage("ApplyDamage", power);
        }
    }
}
