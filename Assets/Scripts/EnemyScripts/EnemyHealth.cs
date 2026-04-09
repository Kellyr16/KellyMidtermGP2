using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int expReward = 10;

    //this following code allows us to use the event OnMonsterDefeated to trigger scripts
    //Scripts that we set up as listeners can look for the event and functions can react
    //Delegate defines what info will be passed along
    public delegate void MonsterDefeated(int exp);
    //the Event allows one piece of code to notify other scripts when something happens
    public static event MonsterDefeated OnMonsterDefeated;

    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if ( currentHealth > maxHealth )
        {
            currentHealth = maxHealth;
        }
        else if ( currentHealth <= 0)
        {
            //this line sends out the delegate with the expRward attached, 
            //scripts we have subscribed can "catch" it and trigger things 
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
}
