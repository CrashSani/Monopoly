using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHUD : MonoBehaviour
{
    public GameObject playerInfoWidget;
    public Transform infoPanel;
    public PlayerFunctions playerfunctions;
    public GameObject endTurnButton;
    public GameObject rollDiceButton;
    GameManager gm;


    void Start()
    {
        gm = GameManager.gm;
        playerfunctions = gm.playerFunctions;
        endTurnButton.SetActive(false);

        LoadInfoWidgets();
    }
    public void OnRoll()
    {
        Debug.Log("Roll Dice");

        gm.audioManager.PlaySoundUniversal(gm.audioManager.clickSound);
        gm.spotFunctions.RollDice();
    }
    public void ToggleEndTurnButton()
    {
        rollDiceButton.SetActive(!rollDiceButton.activeInHierarchy);
        endTurnButton.SetActive(!endTurnButton.activeInHierarchy);

    }
    public void OnManage()
    {
        WidgetManageProperty widget = Instantiate(Resources.Load("Widgets/" + "Widget_ManageProperty") as GameObject, this.transform).GetComponent<WidgetManageProperty>();
        widget.Init();
        gm.audioManager.PlaySoundUniversal(gm.audioManager.clickSound);

    }
    public void EndTurn()
    {
        ToggleEndTurnButton();
        GameManager.gm.spotFunctions.AdvancePlayer();

    }
    private void LoadInfoWidgets()
    {
        for (int i = 0; i < playerfunctions.PlayerCount(); i++)
            
        {
            WidgetPlayerInfo iwidget;
            iwidget = Instantiate(playerInfoWidget, infoPanel).GetComponent<WidgetPlayerInfo>();
            iwidget.InitUI(playerfunctions.players[i]);
        }
    }
    public void ShowSpotInfo(SoSpots _soSpot)
    {
        //WidgetSpotInfo widget = Instantiate(Resources.Load("Widgets/" + "WidgetPropertyInfo") as GameObject, this.transform).GetComponent<WidgetSpotInfo>();
        WidgetSpotBase widget = Instantiate(Resources.Load("Widgets/" + _soSpot.strWidget) as GameObject, this.transform).GetComponent<WidgetSpotBase>();
        widget.Init(_soSpot);
    }
    public void OnPausePressed()
    {
        gm.canvasManager.ShowCanvasOptions();
        gm.audioManager.PlaySoundUniversal(gm.audioManager.clickSound);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gm.spotFunctions.AdvancePlayer();
        }
    }
}

