
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WidgetPlayerSelect : MonoBehaviour
{
    public GameObject buttonAdd;
    public GameObject buttonSelect;

    public Image iPiece;
    public TextMeshProUGUI tPiece;

    public Image iPlayerType;
    public TextMeshProUGUI tPlayerType;

    public Image[] iButtons; //The Image component of the buttons that will change color

    private int playerIdx;
    Player player;
    SoType sotype;
    GameManager gm;
  public void Init(int _idx)
    {
        gm = GameManager.gm;
        playerIdx = _idx;
        player = gm.playerFunctions.players[playerIdx];
        
       
        SetButtonColor();
        DisplayPlayerPiece();
        DisplayPlayerType();
    }
    public void SetButtonColor()
    {
        foreach (Image b in iButtons)
        {
            b.color = player.playerColor;
        }
    }
    public void OnPiecePressed()
    {
        player.IncrementPlayerPiece();
        DisplayPlayerPiece();
        DupePiecesCheck();
    }
    public void OnTypePressed()
    {
        player.IncrementPlayerType();
        DisplayPlayerType();
        gm.canvasManager.canvasSetup.playButton.interactable = gm.currActivePlayers > 1;//replaces else if statement.
    }
     void DisplayPlayerPiece()
    {
        iPiece.sprite = gm.playerFunctions.players[playerIdx].playerPiece.sprPiece;
        tPiece.text = gm.playerFunctions.players[playerIdx].playerPiece.strPiece;
    }
    void DisplayPlayerType()
    {
        iPlayerType.sprite = gm.playerFunctions.players[playerIdx].playerType.sprType;
        tPlayerType.text = gm.playerFunctions.players[playerIdx].playerType.strType;
        if (gm.playerFunctions.players[playerIdx].playerType.type == ePlayerType.none )
        {
            buttonSelect.SetActive(false);
            buttonAdd.SetActive(true);
        }
        else
        {
            buttonSelect.SetActive(true);
            buttonAdd.SetActive(false);
            DupePiecesCheck();
            
        }

    }
    public void DupePiecesCheck()//Checking Each Item in the array for Duplicates Checking Players Array IN GameManager.
    {
        foreach (Player cPlayer in gm.playerFunctions.players)//cPlayer = CurrentPlayer
        {

            if (cPlayer != player)//If equal to ourself 
            {
                if (cPlayer.playerType.type != ePlayerType.none)
                {


                    if (cPlayer.playerPiece == player.playerPiece)
                    {
                        OnPiecePressed();//Checks that it goes from the first one to the last one(Game Pieces)

                    }
                }
            }
        }
    }
}
