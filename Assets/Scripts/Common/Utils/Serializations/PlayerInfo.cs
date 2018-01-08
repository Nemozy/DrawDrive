using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("PlayerInfo")]
public class PlayerInfo
{
    [XmlElement("Coins")]
    public uint _coins = 0;

    //powerups
    [XmlElement("NitroStartPower")]
    public float _nitroStartPower = 1.3f;
    [XmlElement("NitroPower")]
    public float _nitroPower = 20;
    [XmlElement("NitroCooldown")]
    public float _nitroCooldown = 600f;
    [XmlElement("NitroCount")]
    public uint _nitroCount = 999;
    [XmlElement("JumpPower")]
    public float _jumpPower = 6f;
    [XmlElement("JumpCooldown")]
    public float _jumpCooldown = 600f;
    [XmlElement("JumpCount")]
    public uint _jumpCount = 999;
    
    //customize
    [XmlArray("UnlockedCars")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool, CarPrefs>> _unlockedCars = new List<Tuple<uint, bool, CarPrefs>>();

    [XmlElement("CurrentCar")]
    public CarPrefs _currentCar = new CarPrefs();

    public PlayerInfo()
    {
        //FireGTO
        var cp = new CarPrefs
        {
            _model = StringValue.GetStringValue(Collections.CarsEnum.FireGTO)
        };
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
        cp._gasolineMax = 40;
        cp._enginePower = 3;
        cp._maxSpeed = 120;
        cp._gasolineConsumption = 18;
        cp._health = 100;
        cp._driveUnit = (int)Collections.DriveUnitEnum.BackWheelDrive;
        _unlockedCars.Add(new Tuple<uint, bool, CarPrefs>(0, true, cp));

        //focus
        cp = new CarPrefs
        {
            _model = StringValue.GetStringValue(Collections.CarsEnum.Focus)
        };
        cp._unlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(1, false));
        cp._gasolineMax = 55;
        cp._enginePower = 4;
        cp._maxSpeed = 160;
        cp._gasolineConsumption = 14;
        cp._health = 100;
        cp._driveUnit = (int)Collections.DriveUnitEnum.BackWheelDrive;
        _unlockedCars.Add(new Tuple<uint, bool, CarPrefs>(1, false, cp));

        //aventador
        cp = new CarPrefs
        {
            _model = StringValue.GetStringValue(Collections.CarsEnum.Aventador)
        };
        cp._unlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp._unlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp._unlockedColors.Add(new Tuple<uint, bool>(1, false));
        cp._gasolineMax = 80;
        cp._enginePower = 6;
        cp._maxSpeed = 220;
        cp._gasolineConsumption = 22;
        cp._health = 100;
        cp._driveUnit = (int)Collections.DriveUnitEnum.FullWheelDrive;
        _unlockedCars.Add(new Tuple<uint, bool, CarPrefs>(2, false, cp));

        _coins = 1000;

        _currentCar = _unlockedCars[0].third;
    }
}