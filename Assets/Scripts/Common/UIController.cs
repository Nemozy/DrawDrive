using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private StageEnvironment _stage;
    public UnityEngine.UI.Text _message;
    public Transform _speedometerArrow;
    public Transform _gasolineArrow;
    //skills
    //public Transform _skillJump;
    //public Transform _skillNitro;

    void Start ()
    {
        _message.text = "";
    }

    public void SetMessage(string t)
    {
        _message.text = t;
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
        _stage.GetCurrentPlayer().CarJump();
    }


    public void SetNitro()
    {
        _stage.GetCurrentPlayer().CarNitro();
    }

    public void SetStage(StageEnvironment s)
    {
        _stage = s;
    }
}
