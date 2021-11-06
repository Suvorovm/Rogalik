using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform abilityStPoint;
    public GameObject fireballPrefab;
    public float fireballspeed = 10f;

    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("I hit this fucker" + enemy.name);
        }
    }

    public void DistanceAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, abilityStPoint.position, abilityStPoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(abilityStPoint.up * fireballspeed, ForceMode2D.Impulse);
    }
}