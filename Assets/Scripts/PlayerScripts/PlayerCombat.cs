using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    //public float weaponRange = 1;
    public LayerMask enemyLayer;
    //public int damage = 1;

    //public float knockbackForce = 5;
    //public float knockbackTime = 0.25F;
    //public float stunTime = 0.5F;

    public Animator anim;

    //public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if ( timer > 0 )
        {
            timer -= Time.deltaTime;
        }
    }
    
    public void Attack()
    {
        //if the attack cooldown is done, then allow player to attack and set their animation to the attack animation
        if ( timer <= 0 )
        {
            anim.SetBool("isAttacking", true);
            
            timer = StatsManager.Instance.cooldown;
        }
    }

    //Checks if an enemty is in the circle of the game object attached to the player that checks for hits, the adds them to an array, then deals damage to them 
    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer);
            
        if ( enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-StatsManager.Instance.damage);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime);
        }
    }

    //changes the players animationback to idle or moving
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
