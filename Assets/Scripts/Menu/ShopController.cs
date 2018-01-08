using System;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public UnityEngine.UI.Text _message;
    private ShopConf _conf = new ShopConf();
    private Collections.ShopStateEnum _state = Collections.ShopStateEnum.Main;
    private Collections.CarsEnum _currentCar = Collections.CarsEnum.FireGTO;
    private Collections.CarsEnum _defaultCar = Collections.CarsEnum.FireGTO;
    private MenuController _menu;
    private UnityEngine.UI.Text _name;
    private Transform _lock;
    private Transform _set;
    private Transform _buy;
    private UnityEngine.UI.Text _price;

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

    public Transform Lock
    {
        get
        {
            if ((System.Object)_lock == null)
                _lock = transform.FindChild("Lock");
            return _lock;
        }
        set { _lock = value; }
    }

    public Transform Buy
    {
        get
        {
            if ((System.Object)_buy == null)
                _buy = transform.FindChild("Buy");
            return _buy;
        }
        set { _buy = value; }
    }

    public Transform Set
    {
        get
        {
            if ((System.Object)_set == null)
                _set = transform.FindChild("Set");
            return _set;
        }
        set { _set = value; }
    }

    public UnityEngine.UI.Text Price
    {
        get
        {
            if ((System.Object)_price == null)
            {
                if ((System.Object)Buy.FindChild("Price") != null)
                    _price = Buy.FindChild("Price").GetComponent<UnityEngine.UI.Text>();
            }
            return _price;
        }
        set { _price = value; }
    }

    public UnityEngine.UI.Text Name
    {
        get
        {
            if ((System.Object)_price == null)
            {
                if ((System.Object)transform.FindChild("Name") != null)
                    _name = transform.FindChild("Name").GetComponent<UnityEngine.UI.Text>();
            }
            return _name;
        }
        set { _name = value; }
    }

    private void Start()
    {
        _currentCar = (Collections.CarsEnum)Enum.Parse(typeof(Collections.CarsEnum), Menu.GetCurrentCarInfo()._model);
        _defaultCar = _currentCar;
        _state = Collections.ShopStateEnum.Main;
        
        //GOTO: to configs
        _conf._unlockedCars.Add(new ShopConfItem { _model = StringValue.GetStringValue(Collections.CarsEnum.FireGTO), _price = 0 });
        _conf._unlockedCars.Add(new ShopConfItem { _model = StringValue.GetStringValue(Collections.CarsEnum.Focus), _price = 30 });
        _conf._unlockedCars.Add(new ShopConfItem { _model = StringValue.GetStringValue(Collections.CarsEnum.Aventador), _price = 100 });
    }

    private void OnEnable()
    {
        SetDefault();
    }

    private void OnDisable()
    {
        foreach (var c in Menu.GetUnlockedCarsInfo())
        {
            if (c.third._model == StringValue.GetStringValue(_defaultCar) && c.second)
            {
                Menu.SetCurrentCarInfo(c.third);
                Menu.ReloadMainCar();
                break;
            }
        }
    }
    
    public void SetDefault()
    {
        _currentCar = (Collections.CarsEnum)Enum.Parse(typeof(Collections.CarsEnum), Menu.GetCurrentCarInfo()._model);
        _defaultCar = _currentCar;
        _state = Collections.ShopStateEnum.Main;
        var cars = Menu.GetUnlockedCarsInfo();
        if (!cars[(int)_currentCar].second)
        {
            Lock.gameObject.SetActive(true);
            Set.gameObject.SetActive(false);
            Buy.gameObject.SetActive(true);
            Price.text = _conf._unlockedCars[(int)_currentCar]._price.ToString();
        }
        else
        {
            Lock.gameObject.SetActive(false);
            Set.gameObject.SetActive(true);
            Buy.gameObject.SetActive(false);
        }

        Name.text = Menu.GetCurrentCarInfo()._model;
    }

    public void NextElement()
    {
        if (_state == Collections.ShopStateEnum.Main)
        {
            if ((System.Object)Menu != null)
            {
                var vals = Enum.GetValues(typeof(Collections.CarsEnum));
                var j = Array.IndexOf(vals, _currentCar) + 1;
                _currentCar = (vals.Length == j) ? (Collections.CarsEnum)vals.GetValue(0) : (Collections.CarsEnum)vals.GetValue(j);
                var cars = Menu.GetUnlockedCarsInfo();
                foreach (var car in cars)
                {
                    if(car.third._model == StringValue.GetStringValue(_currentCar))
                    {
                        Menu.SetCurrentCarInfo(car.third);
                        Menu.ReloadMainCar();
                        break;
                    }
                }

                if (!cars[(int)_currentCar].second)
                {
                    Lock.gameObject.SetActive(true);
                    Set.gameObject.SetActive(false);
                    Buy.gameObject.SetActive(true);
                    Price.text = _conf._unlockedCars[(int)_currentCar]._price.ToString();
                }
                else
                {
                    Lock.gameObject.SetActive(false);
                    Set.gameObject.SetActive(true);
                    Buy.gameObject.SetActive(false);
                }

                Name.text = Menu.GetCurrentCarInfo()._model;
            }
        }
    }

    public void PreviewElement()
    {
        if (_state == Collections.ShopStateEnum.Main)
        {
            if ((System.Object)Menu != null)
            {
                var vals = Enum.GetValues(typeof(Collections.CarsEnum));
                var j = Array.IndexOf(vals, _currentCar) - 1;
                _currentCar = (j == -1) ? (Collections.CarsEnum)vals.GetValue(vals.Length - 1) : (Collections.CarsEnum)vals.GetValue(j);

                var cars = Menu.GetUnlockedCarsInfo();
                foreach (var car in cars)
                {
                    if (car.third._model == StringValue.GetStringValue(_currentCar))
                    {
                        Menu.SetCurrentCarInfo(car.third);
                        Menu.ReloadMainCar();
                        break;
                    }
                }

                if (!cars[(int)_currentCar].second)
                {
                    Lock.gameObject.SetActive(true);
                    Set.gameObject.SetActive(false);
                    Buy.gameObject.SetActive(true);
                }
                else
                {
                    Lock.gameObject.SetActive(false);
                    Set.gameObject.SetActive(true);
                    Buy.gameObject.SetActive(false);
                }

                Name.text = Menu.GetCurrentCarInfo()._model;
            }
        }
    }

    public void SetItem()
    {
        var c = Serializator.Decode<PlayerInfo>(PlayerPrefsManager.GetString(PrefsNames.PlayerInfo));
        c._currentCar = c._unlockedCars[(int)_currentCar].third;

        PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(c));
        PlayerPrefsManager.Save();

        Menu.ReloadData();

        _defaultCar = (Collections.CarsEnum)Enum.Parse(typeof(Collections.CarsEnum), Menu.GetCurrentCarInfo()._model);
    }

    public void BuyItem()
    {
        var c = Serializator.Decode<PlayerInfo>(PlayerPrefsManager.GetString(PrefsNames.PlayerInfo));
        //price
        if (_conf._unlockedCars[(int)_currentCar]._price > c._coins)
        {
            //error "NO_MONEY"
            _message.text = StringValue.GetStringValue(Collections.ErrorsEnum.NeedMoreMoney);
            _message.gameObject.SetActive(true);
            return;
        }

        c._coins -= _conf._unlockedCars[(int)_currentCar]._price;
        c._currentCar = c._unlockedCars[(int)_currentCar].third;
        c._unlockedCars[(int)_currentCar].second = true;
        _defaultCar = (Collections.CarsEnum)Enum.Parse(typeof(Collections.CarsEnum), c._currentCar._model);

        PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(c));
        PlayerPrefsManager.Save();

        Menu.ReloadData();
        var cars = Menu.GetUnlockedCarsInfo();
        if (!cars[(int)_currentCar].second)
        {
            Lock.gameObject.SetActive(true);
            Set.gameObject.SetActive(false);
            Buy.gameObject.SetActive(true);
        }
        else
        {
            Lock.gameObject.SetActive(false);
            Set.gameObject.SetActive(true);
            Buy.gameObject.SetActive(false);
        }

        Name.text = Menu.GetCurrentCarInfo()._model;
    }
}
