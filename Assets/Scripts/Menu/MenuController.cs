using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private PlayerInfo _playerInfo = new PlayerInfo();

    void Start()
    {
        LoadPlayerInfo();
    }
    
    public void LoadStage()
    {
        SceneManager.LoadScene("SingleStage");
    }

    public void LoadPlayerInfo()
    {

    }
}

class PlayerInfo
{
    //powerups
    public float _nitroPower = 1.3f;
    public uint _nitroCount = 999;
    public float _jumpPower = 6f;
    public uint _jumpCount = 999;

    //customize
    public List<Tuple<uint, bool, CarPrefs>> unlockedCars = new List<Tuple<uint, bool, CarPrefs>>();
    public PlayerInfo()
    {
        var cp = new CarPrefs();
        cp._unlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(2, false));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(3, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(1, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(2, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(3, false));
        cp._unlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(1, false));
        unlockedCars.Add(new Tuple<uint, bool, CarPrefs>(0, true, cp));

        cp = new CarPrefs();
        cp._unlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(1, false));
        unlockedCars.Add(new Tuple<uint, bool, CarPrefs>(1, true, cp));
    }

    public void LoadStats()
    {
        //Лоадим данные новые, если нету. Иначе - выгружаем.
        if(PlayerPrefsManager.GetInt("version") == 0)
        {
            //PlayerPrefsManager.
        }
    }
}

class CarPrefs
{
    public int _usedWheelsModel = 0;
    public int _usedSpoilerModel = 0; //-1
    public int _usedColorModel = 0;

    public List<Tuple<uint, bool>> _unlockedWheels = new List<Tuple<uint, bool>>();
    public List<Tuple<uint, bool>> _unlockedSpoilers = new List<Tuple<uint, bool>>();
    public List<Tuple<uint, bool>> _unlockedColors = new List<Tuple<uint, bool>>();
}