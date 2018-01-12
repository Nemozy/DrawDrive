using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class Serializator
{
    public static BinaryFormatter bf = new BinaryFormatter();

    public static void SaveFile(object serializableObject, string path)
    {
        FileStream file = File.Open(path + ".dtd", FileMode.Create);
        //bf.Serialize(file, serializableObject);
        ////byte[] barr = new UTF8Encoding(true).GetBytes(dataasstring);
        ////file.Write(barr, 0, barr.Length);
        StreamWriter writer = new StreamWriter(file);
        writer.WriteLine(Encode(serializableObject));
        writer.Close();
        file.Close();
    }

    public static T LoadFile<T>(string path)
    {
        if (!File.Exists(path + ".dtd"))
        {
            //error
        }

        FileStream file = File.Open(path + ".dtd", FileMode.Open);
        StreamReader reader = new StreamReader(file);
        var obj = Decode<T>(reader.ReadLine());
        reader.Close();
        file.Close();
        return obj;
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