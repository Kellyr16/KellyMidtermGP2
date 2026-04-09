using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statSlots;
    public CanvasGroup statsCanvas;

    private bool statsOpen = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if ( Input.GetButtonDown("OpenStats"))
        {
            if ( statsOpen )
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
                statsOpen = true;
            }
        }
    }

    //these functions all serve to update the ui when the menu opens
    public void UpdateHealth()
    {
        statSlots[0].GetComponentInChildren<TMP_Text>().text = "HP: " + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
    }

    public void UpdateDamage()
    {
        statSlots[1].GetComponentInChildren<TMP_Text>().text = "Dam: " + StatsManager.Instance.damage;
    }

    public void UpdateSpeed()
    {
        statSlots[2].GetComponentInChildren<TMP_Text>().text = "Spd: " + StatsManager.Instance.speed;
    }

    public void UpdateStrength()
    {
        statSlots[3].GetComponentInChildren<TMP_Text>().text = "Str: " + StatsManager.Instance.knockbackForce;
    }

    public void UpdateDexterity()
    {
        statSlots[4].GetComponentInChildren<TMP_Text>().text = "Dex: " + StatsManager.Instance.stunTime * 10;
    }

    public void UpdateImpact()
    {
        statSlots[5].GetComponentInChildren<TMP_Text>().text = "Imp: " + StatsManager.Instance.knockbackTime * 10;
    }

    public void UpdateRange()
    {
        statSlots[6].GetComponentInChildren<TMP_Text>().text = "Rng: " + StatsManager.Instance.weaponRange;
    }

    public void UpdateCooldown()
    {
        statSlots[7].GetComponentInChildren<TMP_Text>().text = "Cd: " + StatsManager.Instance.cooldown;
    }

    public void UpdateAllStats()
    {
        UpdateHealth();
        UpdateDamage();
        UpdateSpeed();
        UpdateStrength();
        UpdateDexterity();
        UpdateImpact();
        UpdateRange();
        UpdateCooldown();
    }
}
