using UnityEngine;

public class SkillManager : MonoBehaviour
{
    
    //Subscribe to the OnAbilityPointSpent Event on enable
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
    }

    //Unsubscribe from the event on disable
    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
    }


    //Looks at the skill slot the player selects
    //switch statement determines what skill to upgrade based on which button is pressed
    private void HandleAbilityPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        Debug.Log("Just Before Switch");
        switch(skillName)
        {
            case "MaxHealth Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;

            case "Damage":
                StatsManager.Instance.UpdateDamage(1);
                break;

            case "Speed":
                StatsManager.Instance.UpdateSpeed(1);
                break;

            case "Strength":
                StatsManager.Instance.UpdateStrength(1);
                break;

            case "Dexterity":
                StatsManager.Instance.UpdateDexterity(1);
                break;

            case "Impact":
                StatsManager.Instance.UpdateImpact(1);
                break;

            case "Range":
                StatsManager.Instance.UpdateRange(1);
                break;

            case "Cooldown":
            {
                StatsManager.Instance.UpdateCooldown(1);
                break;
            }

            default:
                Debug.LogWarning("Unknown skill" + skillName);
                break;
        }
    }
}
