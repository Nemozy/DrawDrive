using UnityEngine;
using System.Collections.Generic;

public class CacheResources : MonoBehaviour
{
    private static Dictionary<string, GameObject> dicObj = new Dictionary<string, GameObject>();
    private static Dictionary<string, TerrainData> dicTerrains = new Dictionary<string, TerrainData>();

    public static GameObject GetBehaviour(string name)
    {
        if (CacheResources.dicObj == null)
            CacheResources.dicObj = new Dictionary<string, GameObject>();

        if (!CacheResources.dicObj.ContainsKey(name))
            CacheResources.dicObj.Add(name, Resources.Load(FilesURL.GetFileFromResources(name), typeof(GameObject)) as GameObject);

#if UNITY_EDITOR
        if (CacheResources.dicObj[name] == null)
            Debug.Log("Fail! Cant load prefab [" + name + "]");
#endif

        return Instantiate(CacheResources.dicObj[name]);
    }
    public static GameObject GetTerrain(string name)
    {
        if (CacheResources.dicTerrains == null)
            CacheResources.dicTerrains = new Dictionary<string, TerrainData>();

        if (!CacheResources.dicTerrains.ContainsKey(name))
            CacheResources.dicTerrains.Add(name, Resources.Load(FilesURL.GetFileFromResources(name)) as TerrainData);

#if UNITY_EDITOR
        if (CacheResources.dicTerrains[name] == null)
            Debug.Log("Fail! Cant load terrain [" + name + "]");
#endif

        return Terrain.CreateTerrainGameObject(CacheResources.dicTerrains[name]);
    }
}
 