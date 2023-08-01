using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFE : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.gm;
    }
   public void PlayNowPressed()
    {
        //TODO need to go through CanvasManager
        //gm.audioManager.PlaySoundUniversal(gm.audioManager.clickSound);

        gm.LoadScene(eScene.inGame);

    }
    public void OptionsPressed()
    {
        //TODO needs to go through Canvas Manager
        gm.canvasManager.ShowCanvasOptions();
        //GameManager.gm.SpawnOptionsSetup();
    }

    public void PlayNowSetUp()
    {
        gm.canvasManager.ShowCanvas_SetUp();
    }
}
