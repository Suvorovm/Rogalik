using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform abilityStPoint;
    public GameObject fireballPrefab;
    public float fireballspeed=10f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DistanceAttack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("I hit this fucker" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void DistanceAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, abilityStPoint.position, abilityStPoint.rotation);
        Rigidbody2D rb= fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(abilityStPoint.up*fireballspeed,ForceMode2D.Impulse);
    }
}
