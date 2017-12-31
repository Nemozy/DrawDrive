﻿using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerPrefsManager
{
    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(md5(key), encrypt(value));
    }

    public static string GetString(string key, string defaultValue)
    {
        if (!HasKey(key))
            return defaultValue;
        try
        {
            string s = decrypt(PlayerPrefs.GetString(md5(key)));
            return s;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static string GetString(string key)
    {
        return GetString(key, "");
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetString(md5(key), encrypt(value.ToString()));
    }

    public static int GetInt(string key, int defaultValue)
    {
        if (!HasKey(key))
            return defaultValue;
        try
        {
            string s = decrypt(PlayerPrefs.GetString(md5(key)));
            int i = int.Parse(s);
            return i;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static int GetInt(string key)
    {
        return GetInt(key, 0);
    }


    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetString(md5(key), encrypt(value.ToString()));
    }


    public static float GetFloat(string key, float defaultValue)
    {
        if (!HasKey(key))
            return defaultValue;
        try
        {
            string s = decrypt(PlayerPrefs.GetString(md5(key)));
            float f = float.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
            return f;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static float GetFloat(string key)
    {
        return GetFloat(key, 0);
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(md5(key));
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(md5(key));
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    /*
	 * Обязательно смените этот секретный код и числа в массивах
	 */
    private static string secretKey = "secret";
    private static byte[] key = new byte[8] { 22, 41, 18, 47, 38, 217, 65, 64 };
    private static byte[] iv = new byte[8] { 34, 68, 46, 43, 50, 87, 2, 105 };

    private static string encrypt(string s)
    {
        byte[] inputbuffer = Encoding.Unicode.GetBytes(s);
        byte[] outputBuffer = DES.Create().CreateEncryptor(key, iv).TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        return System.Convert.ToBase64String(outputBuffer);
    }

    private static string decrypt(string s)
    {
        byte[] inputbuffer = System.Convert.FromBase64String(s);
        byte[] outputBuffer = DES.Create().CreateDecryptor(key, iv).TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        return Encoding.Unicode.GetString(outputBuffer);
    }

    private static string md5(string s)
    {
        byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(s + secretKey + SystemInfo.deviceUniqueIdentifier));
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }

    /*public static T Load<T>(string filename) where T : class
    {
        if (File.Exists(filename))
        {
            try
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as T;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        return default(T);
    }

    public static void Save<T>(string filename, T data) where T : class
    {
        using (Stream stream = File.OpenWrite(filename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }*/
    /*
    public string LoadString(string k)
    {
        if (PlayerPrefs.HasKey(k))
            return PlayerPrefs.GetString(k);

        return "";
    }

    public float LoadFloat(string k)
    {
        if (PlayerPrefs.HasKey(k))
            return PlayerPrefs.GetFloat(k);

        return 0;
    }

    public int LoadInt(string k)
    {
        if (PlayerPrefs.HasKey(k))
            return PlayerPrefs.GetInt(k);

        return 0;
    }

    public bool SaveString(string k, string v)
    {
        if (PlayerPrefs.HasKey(k))
            return false;

        PlayerPrefs.SetString(k, v);
        PlayerPrefs.Save();
        return true;
    }

    public bool LoadFloat(string k, float v)
    {
        if (PlayerPrefs.HasKey(k))
            return false;

        PlayerPrefs.SetFloat(k, v);
        PlayerPrefs.Save();
        return true;
    }

    public bool LoadInt(string k, int v)
    {
        if (PlayerPrefs.HasKey(k))
            return false;

        PlayerPrefs.SetInt(k, v);
        PlayerPrefs.Save();
        return true;
    }*/
}
