using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGuardianCombat : MonoBehaviour
{
	private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public Transform transform;
    [SerializeField] int power;
    [SerializeField] int knockBackX;
    [SerializeField] int knockBackY;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.O))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        // play attack animation
        animator.SetTrigger("DemonGuardianAttack");

        // find enemies on attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //enemy.GetComponent<PlayerInfo>.takeHit(power, transform, knockBackX, knockBackY);        
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
