using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    private float health;

    private float maxHealth = 1f;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health > 1)
        {
            health = maxHealth;
        }

        if (health < 0)
        {
            health = 0;
        }
        FillHealthBar();
        ChangeColor();
    }

    private void FillHealthBar()
    {
        
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health, 1.2f * Time.deltaTime);
    }

    private void ChangeColor()
    {
        healthBar.color = Color.Lerp(Color.red, Color.green, (health));
    }
    
    /**
     * @return
     * Нанесение опеределенного количество урона (damage)
     */
    public void Damage(float damage)
    {
        if (health>0)
            health -= damage;
    }
    /**
     * @return
     * Восстановление опреденленного количества единиц здоровья (heal)
     */
    public void Heal(float heal)
    {
        if (health < 0)
            health += heal;
    }
    
}