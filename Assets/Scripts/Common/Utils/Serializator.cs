using System;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
//using CloningExtension;

public class Serializator
{
    /*static public void SaveFileXml(RoomState state, string datapath)
    {

        Type[] extraTypes = { typeof(PositData), typeof(Lamp) };
        XmlSerializer serializer = new XmlSerializer(typeof(RoomState), extraTypes);

        FileStream fs = new FileStream(datapath, FileMode.Create);
        serializer.Serialize(fs, state);
        fs.Close();

    }

    static public RoomState LoadFileXml(string datapath)
    {

        Type[] extraTypes = { typeof(PositData), typeof(Lamp) };
        XmlSerializer serializer = new XmlSerializer(typeof(RoomState), extraTypes);

        FileStream fs = new FileStream(datapath, FileMode.Open);
        RoomState state = (RoomState)serializer.Deserialize(fs);
        fs.Close();

        return state;
    }*/

    /*public static void Save(string prefKey, object serializableObject)
    {
        MemoryStream memoryStream = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(memoryStream, serializableObject);
        string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
        PlayerPrefsManager.SetString(prefKey, tmp);
    }

    public static object Load(string prefKey)
    {
        string tmp = PlayerPrefsManager.GetString(prefKey, string.Empty);
        if (tmp == string.Empty)
            return null;
        MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(tmp));
        BinaryFormatter bf = new BinaryFormatter();
        return bf.Deserialize(memoryStream);
    }*/
    public static BinaryFormatter bf = new BinaryFormatter();

    /*public static bool handleNonSerializable
    {
        set
        {
            Serializator.bf.SurrogateSelector = new SurrogateSelector();
            Serializator.bf.SurrogateSelector.ChainSelector(new NonSerialiazableTypeSurrogateSelector());
        }
    }*/

    // serializableObject is any struct or class marked with [Serializable]
    public static void Save(string prefKey, object serializableObject)
    {
        MemoryStream memoryStream = new MemoryStream();
        bf.Serialize(memoryStream, serializableObject);
        string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
        PlayerPrefsManager.SetString(prefKey, tmp);
    }

    public static T Load<T>(string prefKey)
    {
        if (!PlayerPrefsManager.HasKey(prefKey))
            return default(T);

        string serializedData = PlayerPrefsManager.GetString(prefKey);
        MemoryStream dataStream = new MemoryStream(System.Convert.FromBase64String(serializedData));
        T deserializedObject = (T)bf.Deserialize(dataStream);
        return deserializedObject;
    }

    public static string Encode(object serializableObject)
    {
        MemoryStream memoryStream = new MemoryStream();
        bf.Serialize(memoryStream, serializableObject);
        string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
        return tmp;
    }

    public static T Decode<T>(string serialized)
    {
        MemoryStream dataStream = new MemoryStream(System.Convert.FromBase64String(serialized));
        T deserializedObject = (T)bf.Deserialize(dataStream);
        return deserializedObject;
    }
}