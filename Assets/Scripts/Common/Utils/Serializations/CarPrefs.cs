using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("CarPrefs")]
public class CarPrefs
{
    [XmlElement("Model")]
    public string Model = "null";
    [XmlElement("UsedWheelsModel")]
    public int UsedWheelsModel = 0;
    [XmlElement("UsedSpoilerModel")]
    public int UsedSpoilerModel = -1;
    [XmlElement("UsedColorModel")]
    public int UsedColorModel = 0;

    [XmlElement("GasolineMax")]
    public float GasolineMax = 0;
    [XmlElement("EnginePower")]
    public float EnginePower = 0;
    [XmlElement("MaxSpeed")]
    public float MaxSpeed = 0;
    [XmlElement("GasolineConsumption")]
    public float GasolineConsumption = 0;
    [XmlElement("Health")]
    public int Health = 0;
    [XmlElement("DriveUnit")]
    public int DriveUnit = 0;

    [XmlArray("UnlockedWheels")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> UnlockedWheels = new List<Tuple<uint, bool>>();
    [XmlArray("UnlockedSpoilers")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> UnlockedSpoilers = new List<Tuple<uint, bool>>();
    [XmlArray("UnlockedColors")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<uint, bool>> UnlockedColors = new List<Tuple<uint, bool>>();
}