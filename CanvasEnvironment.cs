using UnityEngine.UI;
using UnityEngine;

public class CanvasEnvironment : MonoBehaviour
{
    public Image MainImage;
    public Sprite[] catalog;
    GameManager gm;
    private int currentEnvironmentIdx;

    private void Start()
    {
        gm = GameManager.gm;
        MainImage.sprite = catalog[(int)gm.set.chosenEnvironment];
       
        
    }
    public void DisplayTundraEnvironment()
    {
        MainImage.sprite = catalog[(int)eEnvironment.tundra];
        currentEnvironmentIdx = (int)eEnvironment.tundra;
    }

    public void DisplayGoatEnvironment()
    {
        MainImage.sprite = catalog[(int)eEnvironment.goatisle];
        currentEnvironmentIdx = (int)eEnvironment.goatisle;

    }


    public void DisplayDesertEnvironment()
    {
        MainImage.sprite = catalog[(int)eEnvironment.desert];
        currentEnvironmentIdx = (int)eEnvironment.desert;

    }

    public void DisplaySpaceEnvironment()
    {
        MainImage.sprite = catalog[(int)eEnvironment.space];
        currentEnvironmentIdx = (int)eEnvironment.space;

    }
    public void ConfirmedButton()
    {
        gm.set.chosenEnvironment= (eEnvironment)currentEnvironmentIdx;
        Destroy(this.gameObject);

    }
    public void OnBackButton()
    {
        Destroy(this.gameObject);
    }
    
}
