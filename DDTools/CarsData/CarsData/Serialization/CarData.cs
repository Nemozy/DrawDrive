using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("CarData")]
public class CarData
{
    //stats
    [XmlElement("Model")]
    public string Model = "null";
    [XmlElement("EnginePower")]
    public float EnginePower = 0;
    [XmlElement("DriveUnit")]
    public int DriveUnit = 0;
    [XmlElement("GasolineMax")]
    public float GasolineMax = 0;
    [XmlElement("MaxSpeed")]
    public float MaxSpeed = 0;
    [XmlElement("GasolineConsumption")]
    public float GasolineConsumption = 0;
    [XmlElement("Health")]
    public int Health = 0;
    [XmlElement("Weight")]
    public int Weight = 0;

    [XmlElement("Cost")]
    public int Cost = 0;
    [XmlArray("Items")]
    [XmlArrayItem("Tuple")]
    public List<Types.Tuple<string, List<CarItemData>>> Items = new List<Types.Tuple<string, List<CarItemData>>>();
}

[Serializable]
[XmlRoot("CarItemData")]
public class CarItemData
{
    [XmlElement("Model")]
    public string Model = "null";
    [XmlElement("Level")]
    public int Level = 0;
    [XmlElement("Cost")]
    public int Cost = 0;

    //additional stats
    [XmlElement("EnginePower")]
    public float EnginePower = 0;
    [XmlElement("DriveUnit")]
    public int DriveUnit = 0;
    [XmlElement("GasolineMax")]
    public float GasolineMax = 0;
    [XmlElement("MaxSpeed")]
    public float MaxSpeed = 0;
    [XmlElement("GasolineConsumption")]
    public float GasolineConsumption = 0;
    [XmlElement("Health")]
    public int Health = 0;
    [XmlElement("Weight")]
    public int Weight = 0;
}