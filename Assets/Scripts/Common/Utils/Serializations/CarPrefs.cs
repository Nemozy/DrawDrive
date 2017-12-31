using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("CarPrefs")]
public class CarPrefs
{
    [XmlElement("UsedWheelsModel")]
    public int _usedWheelsModel = 0;
    [XmlElement("UsedSpoilerModel")]
    public int _usedSpoilerModel = 0; //-1
    [XmlElement("UsedColorModel")]
    public int _usedColorModel = 0;

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