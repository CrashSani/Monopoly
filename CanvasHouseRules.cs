using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CanvasHouseRules : MonoBehaviour
{
    public TMP_Dropdown HousesPerProp;
    public TMP_Dropdown HotelLimit;
    public TMP_Dropdown AuctionSwitch;
    public TMP_Dropdown InitialCashSwitch;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.gm;
        HousesPerProp.value = (int)Settings.set.house;
        HotelLimit.value = (int)Settings.set.limit;
        AuctionSwitch.value = (int)Settings.set.auctions;
        InitialCashSwitch.value = (int)Settings.set.cashlim;
    }
    public void OnHouseChange(int _value)
    {
        Debug.Log("New House" + _value);
        Settings.set.house = (eHouse)_value;
    }
    public void OnHotelLimit(int _value)
    {
        Debug.Log("New Limit" + _value);
        Settings.set.limit = (eLimit)_value;
    }
    public void OnAuctions(int _value)
    {
        Debug.Log("New Auction" + _value);
        Settings.set.auctions = (eAuctions)_value;
    }
    public void OnInitialCash(int _value)
    {
        Debug.Log("New Cash Lim" + _value);
        Settings.set.cashlim = (eCashLim)_value;
    }
    public void OnResetPressed()
    {
        HousesPerProp.value = (int)Settings.set.houseDefault;
        HotelLimit.value = (int)Settings.set.limitDefault;
        AuctionSwitch.value = (int)Settings.set.auctionsDefault;
        InitialCashSwitch.value = (int)Settings.set.cashlimDefault;
        gm.audioManager.PlaySoundUniversal(gm.audioManager.clickSound);

    }
}
