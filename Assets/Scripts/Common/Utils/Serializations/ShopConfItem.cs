using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("ShopConfItem")]
public class ShopConfItem
{
    [XmlElement("Model")]
    public string Model = "null";
    [XmlElement("Price")]
    public uint Price = 0;

    //customize
    [XmlArray("Parts")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<string, ShopConfItem>> Parts = new List<Tuple<string, ShopConfItem>>();
}