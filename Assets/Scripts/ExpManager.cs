using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.05f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    public static event Action <int> OnLevelUp;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        //For Debugging and ease of testing, gives exp when clicking enter/return
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExperience(2);
        }
    }

    private void OnEnable()
    {
        //to make the delegate and event code work you need to subscribe to the event
        //this line means tht our GainExperiance function will be added to the list 
        //of functions that are looking for the OnMonsterDefeated
        EnemyHealth.OnMonsterDefeated += GainExperience;
    }

    private void OnDisable()
    {
        //We unsubscribe when this object is disabled
        EnemyHealth.OnMonsterDefeated -= GainExperience;
    }

    //when this function is called the players current xp is added to and checked against the exp needed to level
    public void GainExperience(int amount)
    {
        currentExp += amount; 

        if ( currentExp >= expToLevel )
        {
            LevelUp();
        }

        UpdateUI();
    }

    //increases the playersn level, and adjusts the amount of exp needed to level up again, then gives 10 skill points
    private void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
        OnLevelUp?.Invoke(10);
    }

    //updates the ui to reflect the levelnd exp bar progress
    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
