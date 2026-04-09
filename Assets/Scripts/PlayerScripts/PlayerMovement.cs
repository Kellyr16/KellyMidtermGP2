using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;

    private bool isKnockedBack;

    public PlayerCombat playerCombat;

    private void Update()
    {
        if ( Input.GetButtonDown("Slash") )
        {
            playerCombat.Attack();
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks for horizontal movement via the input managager
        if ( isKnockedBack == false )
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if(horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("Horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("Vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    //Like a method but can be paused, we use it for timers here,
    //This is the time the player is stunned before they can move again
    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime); //wait for stunTime seconds second befoe going to next line
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
