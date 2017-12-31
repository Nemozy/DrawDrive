using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("PlayerInfo")]
public class PlayerInfo
{
    [XmlElement("Coins")]
    public uint _coins = 0;
    //powerups
    [XmlElement("NitroPower")]
    public float _nitroPower = 1.3f;
    [XmlElement("NitroCount")]
    public uint _nitroCount = 999;
    [XmlElement("JumpPower")]
    public float _jumpPower = 6f;
    [XmlElement("JumpCount")]
    public uint _jumpCount = 999;

    //customize
    [XmlArray("UnlockedCars")]
    [XmlArrayItem("Tuple")]
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

        _coins = 10;
    }
}