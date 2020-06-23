using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public GameObject healthBar;
    private RectTransform _healthBarRectTransform;
    private int _maxHealth;
    private int currentHealth;

    public bool IsAlive => currentHealth > 0;

    public void Heal(int count)
    {
        currentHealth = Mathf.Clamp(currentHealth + count, 0, _maxHealth);
    }

    public void Damage(int count)
    {
        currentHealth = Mathf.Clamp(currentHealth - count, 0, _maxHealth);
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
    private void Start()
    {
        _maxHealth = GetComponent<PlayerStats>().maxHealth;
        currentHealth = _maxHealth;
        _healthBarRectTransform = healthBar.GetComponent<RectTransform>();
        print("Health module initialized");
    }

    private void Update()
    {
        SetHealthBarSize(currentHealth);
    }
}
