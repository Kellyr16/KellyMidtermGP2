using UnityEngine;

public class ToggleSkillMenu : MonoBehaviour
{
    public CanvasGroup skillCanvas;
    private bool skillTreeOpen = false;

    // Update is called once per frame
    void Update()
    {
        //Toggles the skill menu
        if ( Input.GetButtonDown("OpenSkills"))
        {
            if ( skillTreeOpen )
            {
                Time.timeScale = 1;
                skillCanvas.alpha = 0;
                skillCanvas.blocksRaycasts = false;
                skillCanvas.interactable = false;
                skillTreeOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                skillCanvas.alpha = 1;
                skillCanvas.blocksRaycasts = true;
                skillCanvas.interactable = true;
                skillTreeOpen = true;
            }
        }
    }
}
