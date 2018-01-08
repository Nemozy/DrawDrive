using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public UnityEngine.UI.Text _message;
    public UnityEngine.UI.Text _coins;
    public Transform _speedometerArrow;
    public Transform _gasolineArrow;

    private StageEnvironment _stage;
    //skills
    public UnityEngine.UI.Text _skillJump;
    public UnityEngine.UI.Image _skillJump_Cooldown;
    public UnityEngine.UI.Text _skillNitro;
    public UnityEngine.UI.Image _skillNitro_Cooldown;

    private float _tickReady_Jump = 0;
    private float _cooldownJump = 300;
    private float _tickReady_Nitro = 0;
    private float _cooldownNitro = 300;

    void Start ()
    {
        _message.text = "";
        var inf = MenuController.LoadPlayerInfo();
        if((System.Object)_skillJump != null)
            _skillJump.text = inf._jumpCount.ToString();
        if ((System.Object)_skillNitro != null)
            _skillNitro.text = inf._nitroCount.ToString();

        _cooldownJump = inf._jumpCooldown;
        _cooldownNitro = inf._nitroCooldown;
    }

    void Update()
    {
        if ((System.Object)_skillJump_Cooldown != null)
            _skillJump_Cooldown.fillAmount = (_tickReady_Jump - _stage.Tick) / _cooldownJump;

        if ((System.Object)_skillNitro_Cooldown != null)
            _skillNitro_Cooldown.fillAmount = (_tickReady_Nitro - _stage.Tick) / _cooldownNitro;
    }

    public void SetMessage(string t)
    {
        _message.text = t;
    }

    public void SetCoins(uint t)
    {
        _coins.text = t.ToString();
    }

    public void SetSpeed(float t, float max)
    {
        var rad = 0;
        if (max == 120) rad = -180;
        else if (max == 140) rad = -220;
        if ((System.Object)_speedometerArrow != null && max > 0)
            _speedometerArrow.eulerAngles = new Vector3(0, 0, rad * t / max);
    }

    public void SetGasoline(float t, float max)
    {
        if ((System.Object)_gasolineArrow != null && max > 0)
            _gasolineArrow.eulerAngles = new Vector3(0, 0, -110 * t / max);
    }

    public void SetJump()
    {
        if (_stage.GetGameState() != Collections.GameStateEnum.START || _tickReady_Jump > _stage.Tick)
            return;

        var inf = MenuController.LoadPlayerInfo();
        if (inf._jumpCount > 0 && _stage.GetCurrentPlayer().CarJump())
        {
            _tickReady_Jump = _stage.Tick + _cooldownJump;
            _skillJump.text = (int.Parse(_skillJump.text) - 1).ToString();
            inf._jumpCount -= 1;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
        }
    }
    
    public void SetNitro()
    {
        if (_stage.GetGameState() != Collections.GameStateEnum.START || _tickReady_Nitro > _stage.Tick)
            return;

        var inf = MenuController.LoadPlayerInfo();
        if (inf._nitroCount > 0 && _stage.GetCurrentPlayer().CarNitro())
        {
            _tickReady_Nitro = _stage.Tick + _cooldownNitro;
            _skillNitro.text = (int.Parse(_skillNitro.text) - 1).ToString();
            inf._nitroCount -= 1;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
        }
    }

    public void SetStage(StageEnvironment s)
    {
        _stage = s;
    }
}
