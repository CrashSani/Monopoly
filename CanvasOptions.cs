
using UnityEngine;
using UnityEngine.UI;

public class CanvasOptions : MonoBehaviour


{


    public GameObject[] inGameHideObjects;
    [NamedArray(typeof(eMixers))] public Slider[] sliders;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.gm;
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = gm.audioManager.volume[i];
        }
        foreach (GameObject g in inGameHideObjects)
        {
            g.SetActive(gm.curScene == eScene.fe);
        }
        
    }
    public void OnMusicSliderChanged()
    {
        //Debug.Log("Music Slider Changed" + sliders[(int)eMixers.music].value);
       gm.audioManager.SetMixerLevel(eMixers.music, sliders[(int)eMixers.music].value, "MusicVol");
    }
    public void OnSoundFXSliderChanged()
    {
        //Debug.Log("Effects Slider Changed" + sliders[(int)eMixers.sound].value);
        gm.audioManager.SetMixerLevel(eMixers.music, sliders[(int)eMixers.music].value, "SoundVol");

    }
    public void OnBackButton()
    {
        Destroy(this.gameObject);
    }

}
