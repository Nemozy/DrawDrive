﻿using UnityEngine;
using System.Collections.Generic;

public class TerrainDrawer : MonoBehaviour
{
    private LineRenderer _curLine;
    private List<Tuple<Vector3, Vector3>> _lines = new List<Tuple<Vector3, Vector3>>();
    private int _countLines = 0;
    private bool _startDraw = false;
    private Vector3 _startDrawPos;
    private Vector3 _endDrawPos;
    private StageEnvironment _stage;

    private StageEnvironment Stage
    {
        get
        {
            if ((System.Object)_stage == null)
                _stage = FindObjectOfType<StageEnvironment>().GetComponent<StageEnvironment>();
            return _stage;
        }
        set
        {
            _stage = value;
        }
    }

    private LineRenderer CurLine
    {
        get
        {
            if ((System.Object)_curLine == null)
            {
                _curLine = gameObject.AddComponent<LineRenderer>();
                _curLine.startWidth = _curLine.endWidth = 2f;
                _curLine.startColor = Color.green;
                _curLine.endColor = Color.green;
            }
            return _curLine;
        }
        set
        {
            _curLine = value;
        }
    }
    
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !_startDraw)
        {
            _countLines++;
            _startDraw = true;
            _startDrawPos = Camera.allCameras[0].ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y, 250));
            
            CurLine.positionCount = _countLines * 2;
            CurLine.SetPosition(_countLines * 2 - 2, _startDrawPos);
            CurLine.SetPosition(_countLines * 2 - 1, _startDrawPos);
        }
        if(_startDraw)
        {
            CurLine.SetPosition(_countLines * 2 - 1, Camera.allCameras[0].ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 250)));
        }
        if (!Input.GetMouseButton(0) && _startDraw)
        {
            _countLines = 0;
            CurLine.positionCount = 0;
            _startDraw = false;
            _endDrawPos = Camera.allCameras[0].ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 250));
            var coeff = Input.mousePosition.x - Camera.allCameras[0].pixelWidth / 2;
            coeff /= Camera.allCameras[0].pixelWidth / 2;
            var tpl = new Tuple<Vector3, Vector3>(new Vector3(_startDrawPos.x - 240, _startDrawPos.y, _startDrawPos.z + 12 + 20 * coeff), new Vector3(_endDrawPos.x - 240, _endDrawPos.y, _endDrawPos.z + 12 + 20 * coeff));
            Stage.DrawTerrainLine(tpl);
            _lines.Add(tpl);
        }
    }
    
    public void LoadToStageHeights()
    {
        _startDraw = false;
        Stage.ReloadStage(_lines);
        Destroy(_curLine);
        Destroy(this);
    }
}
