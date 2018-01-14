using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("PlayerInfo")]
public class PlayerInfo
{
    [XmlElement("Coins")]
    public uint Coins = 0;

    //powerups
    [XmlElement("NitroStartPower")]
    public float NitroStartPower = 1.3f;
    [XmlElement("NitroPower")]
    public float NitroPower = 20;
    [XmlElement("NitroCooldown")]
    public float NitroCooldown = 600f;
    [XmlElement("NitroCount")]
    public uint NitroCount = 999;
    [XmlElement("JumpPower")]
    public float JumpPower = 6f;
    [XmlElement("JumpCooldown")]
    public float JumpCooldown = 600f;
    [XmlElement("JumpCount")]
    public uint JumpCount = 999;
    
    //customize
    [XmlArray("UnlockedCars")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool, CarPrefs>> UnlockedCars = new List<Tuple<uint, bool, CarPrefs>>();

    [XmlElement("CurrentCar")]
    public CarPrefs CurrentCar = new CarPrefs();

    public PlayerInfo()
    {
        //FireGTO
        var cp = new CarPrefs
        {
            Model = StringValue.GetStringValue(Collections.CarsEnum.FireGTO)
        };
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(2, false));
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(3, false));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(1, false));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(2, false));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(3, false));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(1, false));
        cp.GasolineMax = 40;
        cp.EnginePower = 3;
        cp.MaxSpeed = 120;
        cp.GasolineConsumption = 18;
        cp.Health = 100;
        cp.DriveUnit = (int)Collections.DriveUnitEnum.BackWheelDrive;
        UnlockedCars.Add(new Tuple<uint, bool, CarPrefs>(0, true, cp));

        //focus
        cp = new CarPrefs
        {
            Model = StringValue.GetStringValue(Collections.CarsEnum.Focus)
        };
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(1, false));
        cp.GasolineMax = 55;
        cp.EnginePower = 4;
        cp.MaxSpeed = 160;
        cp.GasolineConsumption = 14;
        cp.Health = 100;
        cp.DriveUnit = (int)Collections.DriveUnitEnum.BackWheelDrive;
        UnlockedCars.Add(new Tuple<uint, bool, CarPrefs>(1, false, cp));

        //aventador
        cp = new CarPrefs
        {
            Model = StringValue.GetStringValue(Collections.CarsEnum.Aventador)
        };
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedWheels.Add(new Tuple<uint, bool>(1, false));
        cp.UnlockedSpoilers.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(0, true));
        cp.UnlockedColors.Add(new Tuple<uint, bool>(1, false));
        cp.GasolineMax = 80;
        cp.EnginePower = 6;
        cp.MaxSpeed = 220;
        cp.GasolineConsumption = 22;
        cp.Health = 100;
        cp.DriveUnit = (int)Collections.DriveUnitEnum.FullWheelDrive;
        UnlockedCars.Add(new Tuple<uint, bool, CarPrefs>(2, false, cp));

        Coins = 1000;

        CurrentCar = UnlockedCars[0].third;
    }
}