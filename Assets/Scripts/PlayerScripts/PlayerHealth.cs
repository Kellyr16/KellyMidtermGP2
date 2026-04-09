using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //public int currentHealth;
    //public int maxHealth;

    public SpriteRenderer playerSpriteRend;
    public PlayerMovement playerMovement;

    //changes health and disbales the player if it loses all health
    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;

        if ( StatsManager.Instance.currentHealth <= 0 )
        {
            playerSpriteRend.enabled = false;
            playerMovement.enabled = false;
        }
    }  
}
