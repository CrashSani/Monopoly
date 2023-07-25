
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Canvas_SetUp : MonoBehaviour
{
    public TMP_Dropdown difficultyDropDown;
    public Transform panelSetupButtons;
    public Button playButton;
    GameManager gm;
    private void Start()
    {
        gm = GameManager.gm;
        ShowSetupButtons();
        difficultyDropDown.value = (int)Settings.set.difficulty;
    }
    
    void ShowSetupButtons()
    {
        for (int i = 0; i < GameManager.numPlayers; i++)
        {
            WidgetPlayerSelect widget = Instantiate(Resources.Load("Widgets/" + "Widget_SetPlayer") as GameObject, panelSetupButtons).GetComponent<WidgetPlayerSelect>();
            widget.Init(i);
        }

    }

    public void OnDifficultyChanged(int _value)
    {
        Debug.Log("New Difficulty" + _value);
        Settings.set.difficulty = (eDifficulty)_value;
    }
    public void PlayNowPressed_SetUp()
    {
        //TODO need to go through CanvasManager

        GameManager.gm.LoadScene(eScene.inGame);
    }
    public void PlayHouseRules()
    {
        gm.canvasManager.ShowCanvasHouseRules();

    }
    public void PlayEnvironment()
    {
        gm.canvasManager.ShowCanvasEnvironment();
    }
    public void OnBackButton()
    {

        Destroy(this.gameObject);
    }
    
   
}
