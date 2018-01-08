using System;
using UnityEngine;

public class BoostersShopWindowController : MonoBehaviour
{
    public UnityEngine.UI.Text _message;

    public UnityEngine.UI.Text _jumpCount;
    public UnityEngine.UI.Text _jumpPrice;
    public UnityEngine.UI.Text _jumpPower;
    public UnityEngine.UI.Text _jumpCooldown;
    public UnityEngine.UI.Text _jumpNextPowerUpgrCost;
    public UnityEngine.UI.Text _jumpNextCooldownUpgrCost;

    public UnityEngine.UI.Text _nitroCount;
    public UnityEngine.UI.Text _nitroPrice;
    public UnityEngine.UI.Text _nitroPower;
    public UnityEngine.UI.Text _nitroCooldown;
    public UnityEngine.UI.Text _nitroNextPowerUpgrCost;
    public UnityEngine.UI.Text _nitroNextCooldownUpgrCost;

    private MenuController _menu;

    public MenuController Menu
    {
        get
        {
            if ((System.Object)_menu == null)
                _menu = FindObjectOfType<MenuController>();
            return _menu;
        }
        set { _menu = value; }
    }

    private void OnEnable()
    {
        RefreshVisualDate(MenuController.LoadPlayerInfo());
    }

    private void RefreshVisualDate(PlayerInfo pinf)
    {
        _jumpCount.text = string.Format("x{0}", pinf._jumpCount);
        _jumpPower.text = string.Format("{0}", pinf._jumpPower * 100);
        _jumpCooldown.text = string.Format("{0} sec", pinf._jumpCooldown / 30);

        _nitroCount.text = string.Format("x{0}", pinf._nitroCount);
        _nitroPower.text = string.Format("{0}", pinf._nitroPower);
        _nitroCooldown.text = string.Format("{0} sec", pinf._nitroCooldown / 30);
    }

    public void BuyItem(string n)
    {
        if (n == "nitro")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._nitroCount += 1;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        else if (n == "jump")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._jumpCount += 1;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
    }

    public void UpgradeItem(string n)
    {
        if (n == "nitro_power")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._nitroStartPower += 0.1f;
            inf._nitroPower += 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "nitro_cooldown")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._nitroCooldown -= 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "jump_power")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._jumpPower += 0.5f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "jump_cooldown")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf._coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf._coins -= 10;
            inf._jumpCooldown -= 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
    }
}
