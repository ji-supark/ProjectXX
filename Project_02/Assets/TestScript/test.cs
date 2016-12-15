using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

    public int hp = 100;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // hp -= 10;
        //  print("Cuttent HP : " + hp);
        other.gameObject.SendMessage("TestMessage");
    }
}
