using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("CarPrefs")]
public class CarPrefs
{
    [XmlElement("Model")]
    public string _model = "null";
    [XmlElement("UsedWheelsModel")]
    public int _usedWheelsModel = 0;
    [XmlElement("UsedSpoilerModel")]
    public int _usedSpoilerModel = -1;
    [XmlElement("UsedColorModel")]
    public int _usedColorModel = 0;

    [XmlElement("GasolineMax")]
    public int _gasolineMax = 0;
    [XmlElement("EnginePower")]
    public float _enginePower = 0;
    [XmlElement("MaxSpeed")]
    public int _maxSpeed = 0;
    [XmlElement("GasolineConsumption")]
    public int _gasolineConsumption = 0;
    [XmlElement("Health")]
    public int _health = 0;
    [XmlElement("DriveUnit")]
    public int _driveUnit = 0;

    [XmlArray("UnlockedWheels")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> _unlockedWheels = new List<Tuple<uint, bool>>();
    [XmlArray("UnlockedSpoilers")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> _unlockedSpoilers = new List<Tuple<uint, bool>>();
    [XmlArray("UnlockedColors")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> _unlockedColors = new List<Tuple<uint, bool>>();
}