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
                DrawHeight(el.first, el.second, ref heights, k);
            }
        }

        ter.terrainData.size = new Vector3(1000, 1000, 1000);
        ter.terrainData.heightmapResolution = 1024;
        ter.terrainData.SetHeights(0, 0, heights);
    }

    public void DrawHeight(Vector3 v1, Vector3 v2, ref float[,] h, int j)
    {
        var step = 0.001f;
        var val = 0f;
        if (v2.z < v1.z)
        {
            var d = v1.z - v2.z > 20 ? v1.z - v2.z - 20 : v1.z - v2.z;
            step *= (v1.y - v2.y) / d;
            val = step;
            /*var valDif = val * (v2.z * 10 - 1) / ((v2.z - 10) * 10);
            var v = valDif;
            for (var i = (v2.z * 10 - 1); i > ((v2.z - 10) * 10); i++)
            {
                if (i < 0)
                    break;
                v += valDif;
                h[(int)i/10, j] = v;
            }*/
            for (var i = v2.z; i < v1.z; i++)
            {
                /*if (vd > 20)
                {
                    if (i < v2.z + 10)
                        val -= step / 2;
                    if (i > v1.z - 10)
                        val -= step / 2;
                }*/
                h[(int)i, j] = val;
                val += step;
            }
            /*valDif = val * (v1.z * 10) / ((v1.z + 10) * 10);
            v = valDif;
            for (var i = (v1.z * 10); i > ((v1.z + 10) * 10); i++)
            {
                if (i < 0)
                    break;
                v += valDif;
                h[(int)i / 10, j] = v;
            }*/
        }
        else
        {
            var d = v1.z - v2.z > 20 ? v1.z - v2.z - 20 : v1.z - v2.z;
            step *= (v1.y - v2.y) / d;
            val = step;
            for (var i = v1.z; i < v2.z; i++)
            {
                /*if (vd > 20)
                {
                    if (i < v1.z + 10)
                        val -= step / 2;
                    if (i > v2.z - 10)
                        val -= step / 2;
                }*/
                h[(int)i, j] = val;
                val += step;
            }
        }
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
