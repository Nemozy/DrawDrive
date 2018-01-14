using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Serializator
{
    public static BinaryFormatter bf = new BinaryFormatter();

    public static void SaveFile(string prefKey, object serializableObject)
    {
        MemoryStream memoryStream = new MemoryStream();
        bf.Serialize(memoryStream, serializableObject);
        string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
        PlayerPrefsManager.SetString(prefKey, tmp);
    }

    public static T LoadFile<T>(string prefKey)
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