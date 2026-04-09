using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [Header("Combat Stats")]
    public float damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;
    public float cooldown;

    [Header("Initial Combat Stats")]
    public float initialDamage;
    public float initialWeaponRange;
    public float initialKnockbackForce;
    public float initialKnockbackTime;
    public float initialStunTime;
    public float initialCooldown;

    [Header("Movement Stats")]
    public float speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    [Header("LevelUp Modifiers")]
    public float damageMod = 0.5F;
    public float strengthMod = 0.02F;
    public float dexterityMod = 0.1F;
    public float impactMod = 0.2F;
    public float rangeMod = 0.04F;
    public float cooldownMod = 0.09F;

    private void Awake()
    {
        //check if the stats manager exists, if so destroy it if not make this the instance
        if ( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //all of the updatestat functions work the same, they add to the stat an amount, with some multiplpying that amoun by a set modifier that I calculated
    //based on the original value of the stats, and the upper limit of what i wanted the skills cap to be
    public void UpdateMaxHealth(int amount)
    {
        Debug.Log("UpdateMaxHealth");
        maxHealth += amount;
    }

    public void UpdateDamage(int amount)
    {
        damage += amount * damageMod;
    }

    public void UpdateSpeed(int amount)
    {
        speed += amount;
    }

    public void UpdateStrength(int amount)
    {
        knockbackForce += amount * strengthMod;
    }

    public void UpdateDexterity(int amount)
    {
        stunTime += amount * dexterityMod;
    }

    public void UpdateImpact(int amount)
    {
        knockbackTime += amount * impactMod;
    }

    public void UpdateRange(int amount)
    {
        weaponRange += amount * rangeMod;
    }

    public void UpdateCooldown(int amount)
    {
        cooldown -= amount * cooldownMod;
    }
}
