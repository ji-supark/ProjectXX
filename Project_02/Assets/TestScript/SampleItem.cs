using UnityEngine;
using System.Collections;

public class SampleItem : MonoBehaviour {
    public int addHealth = 50;
    public int applyHealth;

    void Start()
    {
        applyHealth = Random.Range(25, addHealth + 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.SendMessage("ApplyAddHealth", applyHealth);
            Destroy(gameObject);
        }
    }

}
