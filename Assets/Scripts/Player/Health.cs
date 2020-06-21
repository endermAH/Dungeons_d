using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public GameObject healthBar;
    private RectTransform _healthBarRectTransform;
    public int maxHealth = 100;
    private int currentHealth;

    public bool IsAlive => currentHealth > 0;

    public void Heal(int count)
    {
        currentHealth = Mathf.Clamp(currentHealth + count, 0, maxHealth);
    }

    public void Damage(int count)
    {
        currentHealth = Mathf.Clamp(currentHealth - count, 0, maxHealth);
        if (currentHealth == 0)
        {
            this.Death();
        }
    }

    private void SetHealthBarSize(int targetHealth)
    {
        _healthBarRectTransform.sizeDelta = new Vector2(targetHealth , 24);
    }

    public void Death()
    {
        print("Death");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _healthBarRectTransform = healthBar.GetComponent<RectTransform>();
        print("Health module initialized");
    }

    private void Update()
    {
        SetHealthBarSize(currentHealth);
    }
}
