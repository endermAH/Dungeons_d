using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    int currentHP;

    public bool isAlive => currentHP > 0;

    public void Heal(int count)
    {
        currentHP = Mathf.Clamp(currentHP + count, 0, maxHP);
    }

    public void Damage(int count)
    {
        currentHP = Mathf.Clamp(currentHP - count, 0, maxHP);
        if (currentHP == 0)
        {
            this.Death();
        }
    }

    public void Death()
    {
        print("Death");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Health module initialized");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
