using UnityEngine;
using System.Collections;

public class SampleHPBar : MonoBehaviour {

    public int hp = 100;
    public int maxHP;

    public GameObject healthBar;

    public GameObject[] itemBox;
	
	void Start () {
        maxHP = hp;
	}
	
	void Update () {
        if (hp <= 0)
            isDead();
	}

    void isDead()
    {
        int i = Random.Range(0, itemBox.Length - 1);

        GameObject insItem = Instantiate(itemBox[i], transform.position
            , Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }

    void ApplyAddHealth(int addHealth)
    {
        hp += addHealth;

        if (hp > maxHP)
            hp = maxHP;

        float calcHealth = (float)hp / maxHP;

        SetHealthBar(calcHealth);

    }

    void ApplyDamage(int damage)
    {
        hp -= damage;
        
        if (hp < 0)
            hp = 0;

        float calcHealth = (float)hp / maxHP;

        SetHealthBar(calcHealth);
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(
            myHealth, healthBar.transform.localScale.y,
            healthBar.transform.localScale.z);
    }
}
