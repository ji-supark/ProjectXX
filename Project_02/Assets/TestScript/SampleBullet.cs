using UnityEngine;
using System.Collections;

public class SampleBullet : MonoBehaviour{
    public int power = 10; //총알의 공격력.

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.gameObject.SendMessage("ApplyDamage", power);
        }
    }
}
