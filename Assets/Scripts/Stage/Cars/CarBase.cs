using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : BaseBehaviour
{
    private Rigidbody _rig;
    private float _speed = 0;
    private float _maxSpeed = 120;
    private float _motorTorque = 100f;
    private float _maxTorque = -260;
    private float _motorTorque_coeff = 3; //engine power
    private float _motorBreak = -100f;
    private float _maxGasoline = 40;
    private float _gasoline = 40;
    private float _gasolineConsumption = 18;
    private float _jumpPower = 5;

    private float _hp = 100;
    private float _maxHp = 100;
    private bool _explosion = false;

    private bool _onWheels = true;
    private float _nitroDuration = 180;
    private float _nitroTickStart = 0;
    private float _nitroPower = 20;
    private float _nitroCoeff = 1.5f;
    private Collections.DriveUnitEnum _driveUnit = Collections.DriveUnitEnum.BackWheelDrive;

    public WheelCollider _leftBackWheel;
    public WheelCollider _rightBackWheel;
    public WheelCollider _leftForwardWheel;
    public WheelCollider _rightForwardWheel;
    public Collider _bodyCollider;
    public GameObject _nitroAnimation;
    public GameObject _explosionAnimation;

    public float Gasoline
    {
        get
        {
            if (_gasoline < 0)
                return 0;
            return _gasoline;
        }
        set
        {
            _gasoline = value;
        }
    }
    public float MaxGasoline
    {
        get
        {
            return _maxGasoline;
        }
    }
    public float MaxSpeed
    {
        get
        {
            return _maxSpeed;
        }
    }
    public float Speed
    {
        get
        {
            if (_speed < 1)
                return 0;
            return _speed;
        }
        set
        {
            if (value > _maxSpeed)
                _speed = _maxSpeed;
            else
                _speed = value;
        }
    }

    protected override void OnStart()
    {
        _nitroAnimation.SetActive(false);
        _nitroAnimation.GetComponent<DigitalRuby.PyroParticles.FireBaseScript>().Stop();
        _rig = GetComponent<Rigidbody>();
         Speed = Mathf.Abs(_rig.velocity.magnitude * 3.6f)/*To km/h     ///  to m/h 2.237f */;
    }

    protected override void OnUpdateBehaviour()
    {
        if (_nitroTickStart + _nitroDuration == _sceneTick)
        {
            _maxSpeed -= _nitroPower;
            _motorTorque /= _nitroCoeff;
            _nitroAnimation.SetActive(false);
        }

        if(_hp <= 0 && !_explosion)
        {
            _leftBackWheel.motorTorque = 0;
            _rightBackWheel.motorTorque = 0;
            _leftForwardWheel.motorTorque = 0;
            _rightForwardWheel.motorTorque = 0;
            Gasoline = 0;

            _explosion = true;
            _explosionAnimation.gameObject.SetActive(true);
            Jump();
        }

        _player.IncreaseScore(Speed * 0.01f);
        _player.IncreaseScore(_rig.position.y * Speed * 0.1f);
        _onWheels = _leftBackWheel.isGrounded || _rightBackWheel.isGrounded || _leftForwardWheel.isGrounded || _rightForwardWheel.isGrounded;
        if (!_onWheels || Gasoline == 0)
        {
            _leftBackWheel.motorTorque = 0;
            _rightBackWheel.motorTorque = 0;
            _leftForwardWheel.motorTorque = 0;
            _rightForwardWheel.motorTorque = 0;
            if(Gasoline == 0)
            {
                if (_driveUnit == Collections.DriveUnitEnum.BackWheelDrive || _driveUnit == Collections.DriveUnitEnum.FullWheelDrive)
                {
                    _leftBackWheel.brakeTorque = _maxTorque * _motorBreak;
                    _rightBackWheel.brakeTorque = _maxTorque * _motorBreak;
                }
                if (_driveUnit == Collections.DriveUnitEnum.FrontWheelDrive || _driveUnit == Collections.DriveUnitEnum.FullWheelDrive)
                {
                    _leftForwardWheel.brakeTorque = _maxTorque * _motorBreak;
                    _rightForwardWheel.brakeTorque = _maxTorque * _motorBreak;
                }
            }
        }
    }

    public void SetPrefs(CarPrefs cp)
    {
        _maxHp = _hp = cp._health;
        _maxGasoline = _gasoline = cp._gasolineMax;
        _motorTorque_coeff = cp._enginePower;
        _gasolineConsumption = cp._gasolineConsumption;
        _maxSpeed = cp._maxSpeed;
        _driveUnit = (Collections.DriveUnitEnum)cp._driveUnit;
    }

    public void Force()
    {
        if ((System.Object)_rig == null)
            return;
        _onWheels = _leftBackWheel.isGrounded || _rightBackWheel.isGrounded || _leftForwardWheel.isGrounded || _rightForwardWheel.isGrounded;
        if (_onWheels && Gasoline > 0)
        {
            if (Speed < _maxSpeed)
            {
                if (_driveUnit == Collections.DriveUnitEnum.BackWheelDrive || _driveUnit == Collections.DriveUnitEnum.FullWheelDrive)
                {
                    _leftBackWheel.motorTorque = _maxTorque * _motorTorque * _motorTorque_coeff;
                    _rightBackWheel.motorTorque = _maxTorque * _motorTorque * _motorTorque_coeff;
                }
                if (_driveUnit == Collections.DriveUnitEnum.FrontWheelDrive || _driveUnit == Collections.DriveUnitEnum.FullWheelDrive)
                {
                    _leftForwardWheel.motorTorque = _maxTorque * _motorTorque * _motorTorque_coeff;
                    _rightForwardWheel.motorTorque = _maxTorque * _motorTorque * _motorTorque_coeff;
                }
            }
            else
            {
                _leftBackWheel.motorTorque = 0;
                _rightBackWheel.motorTorque = 0;
                _leftForwardWheel.motorTorque = 0;
                _rightForwardWheel.motorTorque = 0;
            }
        }
        if(Gasoline > 0)
            Gasoline = Gasoline - _gasolineConsumption / 5 * Time.deltaTime;
        Speed = Mathf.Abs(_rig.velocity.magnitude * 3.6f)/*To km/h     ///  to m/h 2.237f */;//Vector3.Distance(_lastPos, wanaPos);
    }

    public bool Jump()
    {
        if (_onWheels && Gasoline > 0)
        {
            _rig.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
            return true;
        }
        return false;
    }

    public bool Nitro()
    {
        if (Gasoline > 0)
        {
            _nitroAnimation.SetActive(true);
            _nitroAnimation.GetComponent<DigitalRuby.PyroParticles.FireBaseScript>().Duration = _nitroDuration;
            _nitroAnimation.GetComponent<DigitalRuby.PyroParticles.FireBaseScript>().NeedStart();
            _rig.AddForce(Vector3.forward * _nitroCoeff, ForceMode.VelocityChange);
            _nitroTickStart = _sceneTick;
            _maxSpeed += _nitroPower;
            _motorTorque *= _nitroCoeff;

            return true;
        }
        return false;
    }

    public void OnCollisionEnter(Collision c)
    {
        if(c != null)
        {
            _hp -= 10;
        }
    }

    public void OnCollisionStay(Collision c)
    {
        if(c != null && _hp > 0)
            _hp -= Time.deltaTime;
    }
}