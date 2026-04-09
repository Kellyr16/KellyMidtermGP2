using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;


    //subscripe to OnAbilityPointSpent and OnLevelUp
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
        ExpManager.OnLevelUp += UpdateAbilityPoints;
    }

    private void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
        ExpManager.OnLevelUp += UpdateAbilityPoints;
    }

    private void Start()
    {
        //add listeners to each button in the skill menu
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(() => CheckAvailablePoints(slot));
        }
        
        UpdateAbilityPoints(0);
    }
    
    //Checks if the player has any skill points
    private void CheckAvailablePoints(SkillSlot slot)
    {
        if ( availablePoints > 0 )
        {
            slot.TryUpgradeSkill();
        }
    }
    //Checks if an ability point was spent and takes one point away 
    private void HandleAbilityPointSpent(SkillSlot skillSlot)
    {
        if ( availablePoints > 0 )
        {
            UpdateAbilityPoints(-1);
        }
    }

    //onlevel up, add skill points to the available amount
    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points: " + availablePoints;
    }
}
