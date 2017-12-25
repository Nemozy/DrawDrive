using UnityEngine;

public class PlayerController
{
    private CarBase _car;
    private int _tileSize;
    private StageEnvironment _stage;
    private float _score = 0;

    public PlayerController(int s, StageEnvironment stage)
    {
        _tileSize = s;
    }
    
    public float IncreaseScore(float s)
    {
        return (_score += s);
    }

    public float GetScore()
    {
        return Mathf.CeilToInt(_score);
    }

    public void SetCar(CarBase c)
    {
        _car = c;
        _car.SetPlayer(this);
    }

    public void SetCarPosition(Vector3 p)
    {
        _car.gameObject.transform.position = p * _tileSize;
    }

    public void SetCarRotation(Vector3 r)
    {
        _car.gameObject.transform.rotation *= Quaternion.Euler(r);
    }

    public void CarForce()
    {
        _car.Force();
    }

    public void CarJump()
    {
        _car.Jump();
    }

    public void CarNitro()
    {
        _car.Nitro();
    }

    public float GetCarGasoline()
    {
        if ((System.Object)_car == null)
            return 0;
        return _car.Gasoline;
    }
    public float GetCarMaxGasoline()
    {
        if ((System.Object)_car == null)
            return 0;
        return _car.MaxGasoline;
    }
    public float GetCarSpeed()
    {
        if ((System.Object)_car == null)
            return 0;
        return _car.Speed;
    }
    public float GetCarMaxSpeed()
    {
        if ((System.Object)_car == null)
            return 0;
        return _car.MaxSpeed;
    }
}