using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public UIController _uiController;
    private PlayerInfo _playerInfo = new PlayerInfo();

    void Start()
    {
        _playerInfo = MenuController.LoadPlayerInfo();
        _uiController.SetCoins(_playerInfo._coins);
    }
    
    public void LoadStage()
    {
        SceneManager.LoadScene("SingleStage");
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