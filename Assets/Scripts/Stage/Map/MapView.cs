using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView
{
    private GameObject _terrain;
    private Dictionary<int, GameObject> _objDic;

    public MapView()
    {
        _objDic = new Dictionary<int, GameObject>();
    }

    public void SetTerrain(string n, List<Tuple<Vector3, Vector3>> t)
    {
        if ((System.Object)_terrain != null)
            GameObject.Destroy(_terrain);
        _terrain = CacheResources.GetTerrain(n);
        _terrain.tag = "Ground";
        var ter = _terrain.GetComponent<Terrain>();
        var heights = new float[1000, 1000];
        for (var i = 0; i < 1000; i++)
            for (var j = 0; j < 1000; j++)
                heights[i, j] = 0;
        
        for (var k = 492; k < 513; k++)
        {
            foreach (var el in t)
            {
                heights = DrawHeight(el.first, el.second, heights, k);
            }
        }

        ter.terrainData.size = new Vector3(1000, 1000, 1000);
        ter.terrainData.heightmapResolution = 1024;
        ter.terrainData.SetHeights(0, 0, heights);
    }

    public float[,] DrawHeight(Vector3 v1, Vector3 v2, float[,] h, int j)
    {
        float[,] ret = h;
        var step = 0.001f;
        var val = 0f;
        if (v2.z < v1.z)
        {
            var d = v2.z - v1.z > 20 ? v2.z - v1.z - 20 : v2.z - v1.z;
            step *= (v2.y - v1.y) / d;
            for (int i = -1; i >= -10; i--)
            {
                ret[Mathf.RoundToInt(v2.z - i), j] = step * 10 / (i - 0);
            }
            val = step;
            for (int i = Mathf.RoundToInt(v2.z + 10); i < Mathf.RoundToInt(v1.z - 10); i++)
            {
                ret[i, j] = val;
                val += step;
            }
            for (int i = 1; i <= 10; i++)
            {
                ret[Mathf.RoundToInt(v1.z - 10 + i), j] = step * 10 / (i - 0);
            }
            val += step;
        }
        else
        {
            var d = v1.z - v2.z > 10 ? v1.z - v2.z - 10 : v1.z - v2.z;
            step *= (v1.y - v2.y) / d;
            for (int i = -1; i >= -10; i--)
            {
                ret[Mathf.RoundToInt(v1.z + 1 + i), j] = step / (0 - i);
            }
            val = step;
            for (int i = Mathf.RoundToInt(v1.z); i < Mathf.RoundToInt(v2.z - 4); i++)
            {
                ret[i, j] = val;
                val += step;
            }
            for (int i = 1; i <= 5; i++)
            {
                ret[Mathf.RoundToInt(v2.z - i), j] = step * 10 / (0 - i) + val;
            }
            val += step;
        }
        return ret;
    }

    public void AddNewCell(int id, string name, int x, int y)
    {
        if (_objDic.ContainsKey(id))
        {
#if UNITY_EDITOR
            Debug.Log("Fail! Prefab [" + name + "] must be singleton");
#endif
            return;
        }
        _objDic.Add(id, CacheResources.GetBehaviour(name));
        _objDic[id].transform.SetPositionAndRotation(new Vector3(x, 0, y), _objDic[id].transform.rotation);
    }
}
