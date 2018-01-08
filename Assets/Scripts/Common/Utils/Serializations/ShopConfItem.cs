using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("ShopConfItem")]
public class ShopConfItem
{
    [XmlElement("Model")]
    public string _model = "null";
    [XmlElement("Price")]
    public uint _price = 0;

    //customize
    [XmlArray("Parts")]
    [XmlArrayItem("Tuple")]
    public List<Tuple<string, ShopConfItem>> _parts = new List<Tuple<string, ShopConfItem>>();
}