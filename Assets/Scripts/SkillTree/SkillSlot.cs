using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;

    public float currentStatValue;
    
    public Image skillIcon;
    public Button skillButton;
    public TMP_Text skillLevelText;
    //public TMP_Text skillName;

    public static event Action<SkillSlot> OnAbilityPointSpent;



    //runs any time you make changes to a scripts variable
    private void OnValidate()
    {
        if ( skillSO != null && skillLevelText != null )
        {
            UpdateUI();
        }
    }

    //nicely handles all the skill by sending the current button being pressed over to SkillManager
    //the commented functions below are more complicated and are only here as backup in case something fails with this one
    public void TryUpgradeSkill()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            Debug.Log("TryUpgradeSkill");
            OnAbilityPointSpent?.Invoke(this);
            currentStatValue++;
            UpdateUI();
        }
    }
    /*public void TryUpgradeSkillHealth()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue++;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillSpeed()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue++;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillDamage()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialDamage * damageMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillStrength()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialKnockbackForce * strengthMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillDexterity()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialStunTime * dexterityMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillImpact()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialKnockbackTime * impactMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillRange()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialWeaponRange * rangeMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }

    public void TryUpgradeSkillLuck()
    {
        if ( currentStatValue < skillSO.maxLevel )
        {
            currentStatValue += StatsManager.Instance.initialExpMultiplier * luckMod;
            OnAbilityPointSpent?.Invoke(this);
        }
    }*/


    private void UpdateUI()
    {
        skillButton.interactable = true;
        skillIcon.sprite =  skillSO.skillIcon;
        skillLevelText.text = currentStatValue.ToString();
    }
}
