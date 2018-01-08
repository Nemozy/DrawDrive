using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("ShopConf")]
public class ShopConf
{
    [XmlArray("Cars")]
    [XmlArrayItem("ShopConfItem")]
    public List<ShopConfItem> _unlockedCars = new List<ShopConfItem>();
}