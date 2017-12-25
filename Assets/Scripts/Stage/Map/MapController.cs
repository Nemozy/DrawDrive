using System.Collections.Generic;
using UnityEngine;

public class MapController
{
    private MapView _view;
    private List<List<MapCellState>> _map;
    private int _height = 0;
    private int _width = 0;
    private int _tileSize = 10;
    private List<Tuple<Vector3, Vector3>> heights = new List<Tuple<Vector3, Vector3>>();
    private Collections.TerrainsEnum terrStyle;

    public List<List<MapCellState>> Map
    {
        get
        {
            if (_map == null)
                GenerateNewMap(_width, _height, Collections.TerrainsEnum.SingleStage, new List<Tuple<Vector3, Vector3>>());

            return _map;
        }
    }
    public MapView View
    {
        get
        {
            if (_view == null)
                _view = new MapView();

            return _view;
        }
    }

    public int GetTileSize()
    {
        return _tileSize;
    }

    public void AddNewLine(Tuple<Vector3, Vector3> t)
    {
        heights.Add(t);
        View.SetTerrain(StringValue.GetStringValue(terrStyle), heights);
    }

    public void GenerateNewMap(int w, int h, Collections.TerrainsEnum t, List<Tuple<Vector3, Vector3>> l)
    {
        terrStyle = t;
        View.SetTerrain(StringValue.GetStringValue(terrStyle), l);
        _height = h;
        _width = w;
        _map = new List<List<MapCellState>>();
        var generatedId = 0;
        for(var i = 0; i < h; i++)
        {
            _map.Add(new List<MapCellState>());
            for (var j = 0; j < w; j++)
            {
                var tmp = new MapCellState
                {
                    Id = ++generatedId,
                    PrefabType = Collections.RoadPrefabsEnum.RoadStraight,
                    Pathability = false                  //TODO: false - default
                };
                _map[i].Add(tmp);
                //View.AddNewCell(tmp.Id, tmp.PrefabType, _tileSize * j, _tileSize * i);
            }
        }
    }

    public void PathabilityCell(int x, int y, bool p)
    {
        if (_height > y && _width > x)
        {
            Map[y][x] = new MapCellState { Id = Map[y][x].Id, Pathability = p, PrefabType = Map[y][x].PrefabType };
            View.AddNewCell(Map[y][x].Id, StringValue.GetStringValue(Map[y][x].PrefabType), _tileSize * x, _tileSize * y);
        }
    }
    
    public struct MapCellState
    {
        public int Id;
        public bool Pathability;
        public Collections.RoadPrefabsEnum PrefabType;
    }
}
