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
        _jumpCount.text = string.Format("x{0}", pinf.JumpCount);
        _jumpPower.text = string.Format("{0}", pinf.JumpPower * 100);
        _jumpCooldown.text = string.Format("{0} sec", pinf.JumpCooldown / 30);

        _nitroCount.text = string.Format("x{0}", pinf.NitroCount);
        _nitroPower.text = string.Format("{0}", pinf.NitroPower);
        _nitroCooldown.text = string.Format("{0} sec", pinf.NitroCooldown / 30);
    }

    public void BuyItem(string n)
    {
        if (n == "nitro")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.NitroCount += 1;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        else if (n == "jump")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.JumpCount += 1;
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
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.NitroStartPower += 0.1f;
            inf.NitroPower += 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "nitro_cooldown")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.NitroCooldown -= 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "jump_power")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.JumpPower += 0.5f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
        if (n == "jump_cooldown")
        {
            var inf = MenuController.LoadPlayerInfo();
            //price
            if (10 > inf.Coins)
            {
                //error "NO_MONEY"
                _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
                _message.gameObject.SetActive(true);
                return;
            }
            inf.Coins -= 10;
            inf.JumpCooldown -= 1f;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
            RefreshVisualDate(inf);
            Menu.ReloadData();
        }
    }
}
