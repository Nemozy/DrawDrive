using System;
using UnityEngine;

public class CarUpgradesShopWindowController : MonoBehaviour
{
    public UnityEngine.UI.Text _message;

    public UnityEngine.UI.Text _enginePower;
    public UnityEngine.UI.Text _gasolineMax;
    public UnityEngine.UI.Text _gasolineConsumption;

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

    public void UpgradeItem(string n)
    {
        if (n == "engine_power")
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

            foreach (var car in inf.UnlockedCars)
            {
                if (car.third.Model == inf.CurrentCar.Model)
                {
                    car.third.EnginePower += 0.01f;
                    car.third.MaxSpeed += 0.25f;
                    car.third.GasolineConsumption -= 0.05f;
                    PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
                    PlayerPrefsManager.Save();
                    RefreshVisualDate(inf);
                    Menu.ReloadData();
                    break;
                }
            }
        }
        else if (n == "gasoline_max")
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

            foreach (var car in inf.UnlockedCars)
            {
                if (car.third.Model == inf.CurrentCar.Model)
                {
                    car.third.GasolineMax += 0.25f;
                    PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
                    PlayerPrefsManager.Save();
                    RefreshVisualDate(inf);
                    Menu.ReloadData();
                    break;
                }
            }
        }
        else if(n == "gasoline_consumption")
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

            foreach (var car in inf.UnlockedCars)
            {
                if (car.third.Model == inf.CurrentCar.Model)
                {
                    car.third.GasolineConsumption -= 0.1f;
                    PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
                    PlayerPrefsManager.Save();
                    RefreshVisualDate(inf);
                    Menu.ReloadData();
                    break;
                }
            }
        }
    }

    private void RefreshVisualDate(PlayerInfo pinf)
    {
        _enginePower.text = string.Format("x{0} h/p", pinf.CurrentCar.EnginePower * 100);
        _gasolineMax.text = string.Format("{0}", pinf.CurrentCar.GasolineMax);
        _gasolineConsumption.text = string.Format("{0}", pinf.CurrentCar.GasolineConsumption);
    }
}
