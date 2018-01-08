using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public UIController _uiController;
    public Transform _carParent;
    private PlayerInfo _playerInfo = new PlayerInfo();

    void Start()
    {
        _playerInfo = MenuController.LoadPlayerInfo();
        _uiController.SetCoins(_playerInfo._coins);
        ReloadMainCar();
    }

    public void LoadStage()
    {
        SceneManager.LoadScene("SingleStage");
    }

    public CarPrefs GetCurrentCarInfo()
    {
        return _playerInfo._currentCar;
    }

    public List<Tuple<uint,bool, CarPrefs>> GetUnlockedCarsInfo()
    {
        return _playerInfo._unlockedCars;
    }

    public void SetCurrentCarInfo(CarPrefs p)
    {
        _playerInfo._currentCar = p;
    }

    public void ReloadData()
    {
        _playerInfo = MenuController.LoadPlayerInfo();
        _uiController.SetCoins(_playerInfo._coins);
        ReloadMainCar();
    }

    public void ReloadMainCar()
    {
        var obj = CacheResources.GetBehaviour(_playerInfo._currentCar._model);
        if((System.Object)obj != null)
        {
            for (var i = 0; i < _carParent.childCount; i++)
            {
                Destroy(_carParent.GetChild(i).gameObject);
            }
        }
        obj.transform.SetParent(_carParent);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
        obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        _carParent.transform.localRotation = Quaternion.Euler(0, 200, 0);
    }

    public static PlayerInfo LoadPlayerInfo()
    {
        //Лоадим данные новые, если нету. Иначе - выгружаем.
        if (PlayerPrefsManager.GetFloat(PrefsNames.Version) == 0)
        {
            PlayerPrefsManager.SetFloat(PrefsNames.Version, CacheResources._version);
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(new PlayerInfo()));
            PlayerPrefsManager.Save();
        }
        return Serializator.Decode<PlayerInfo>(PlayerPrefsManager.GetString(PrefsNames.PlayerInfo));
    }
}