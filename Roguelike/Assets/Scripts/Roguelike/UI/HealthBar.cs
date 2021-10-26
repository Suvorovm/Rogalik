using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        UpdateBar(1f);
    }

    // private void Update()
    // {
    //     UpdateBar(0.5f);
    // }

    public void UpdateBar(float health)
    {
         healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health, 1.2f * Time.deltaTime);
        ChangeColor(health);
    }

    private void ChangeColor(float health)
    {
         healthBar.color = Color.Lerp(Color.red, Color.green, (health));
    }
    
    /**
     * @return
     * Нанесение опеределенного количество урона (damage)
     */
    // public void Damage(float damage,float health)
    // {
    //     if (health>0)
    //         health -= damage;
    // }
    // /**
    //  * @return
    //  * Восстановление опреденленного количества единиц здоровья (heal)
    //  */
    // public void Heal(float heal,float health)
    // {
    //     if (health < 0)
    //         health += heal;
    // }
    
}