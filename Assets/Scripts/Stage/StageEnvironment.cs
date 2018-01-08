using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StageEnvironment : MonoBehaviour
{
    public UIController _uiController;
    public Transform _camera;
    private int _globalTick = 0;
    private int _readyToStartTick = 0;
    private MapController _map;
    private PlayerController _playerController;
    private List<BaseBehaviour> _behaviours;
    private Collections.GameStateEnum _gameState = Collections.GameStateEnum.WAITING;
    private PlayerInfo _playerInfo = new PlayerInfo();

    public int Tick
    {
        get { return _globalTick; }
    }
    
    void Start ()
    {
        _behaviours = new List<BaseBehaviour>();
        _globalTick = 0;
        _playerInfo = MenuController.LoadPlayerInfo();
        _map = new MapController();
        _map.GenerateNewMap(100, 100, Collections.TerrainsEnum.SingleStage, new List<Tuple<Vector3, Vector3>>());
        _playerController = new PlayerController(_map.GetTileSize(), this);
        _camera.GetComponent<CameraFollowing>().SetTarget(null);
        _uiController.SetStage(this);
        /*var c = CacheResources.GetBehaviour(StringValue.GetStringValue(Collections.CarsEnum.FireGTO)).GetComponent<CarBase>();
        _playerController.SetCar(c);
        _behaviours.Add(c);
        _camera.GetComponent<CameraFollowing>().SetTarget(c.gameObject.transform);
        _playerController.SetCarPosition(new Vector3(4,0.1f,1));
        _playerController.SetCarRotation(new Vector3(0,180,0));*/
    }

    private void Update()
    {
        if ((System.Object)_playerController != null)
        {
            _uiController.SetSpeed(_playerController.GetCarSpeed(), _playerController.GetCarMaxSpeed());
            _uiController.SetGasoline(_playerController.GetCarGasoline(), _playerController.GetCarMaxGasoline());
        }
    }

    void FixedUpdate ()
    {
        //_playerController.CarForce();
        //foreach (var behaviour in _behaviours)
        //  behaviour.UpdateBehaviour(Tick);
        if (_gameState == Collections.GameStateEnum.WAITING)
            return;

        if (_gameState == Collections.GameStateEnum.READY_TO_START)
        {
            if (_readyToStartTick + 90 == _globalTick)
            {
                _uiController.SetMessage("2");
            }
            if (_readyToStartTick + 150 == _globalTick)
            {
                _uiController.SetMessage("1");
            }
            if (_readyToStartTick + 210 == _globalTick)
            {
                _uiController.SetMessage("START");
            }
            if (_readyToStartTick + 270 == _globalTick)
            {
                _uiController.SetMessage("");
                _gameState = Collections.GameStateEnum.START;
            }
        }
        if (_gameState == Collections.GameStateEnum.START)
        {
            _playerController.CarForce();
            foreach (var behaviour in _behaviours)
              behaviour.UpdateBehaviour(Tick);

            if (_playerController.GetCarGasoline() == 0 && _playerController.GetCarSpeed() == 0)
                _gameState = Collections.GameStateEnum.WIN;
        }
        if (_gameState == Collections.GameStateEnum.WIN)
        {
            _uiController.SetMessage("Score: " + _playerController.GetScore() + '\n' + "coins: +3");
            _uiController.transform.Find("MenuButton").gameObject.SetActive(true);
            _gameState = Collections.GameStateEnum.END;
            var inf = MenuController.LoadPlayerInfo();
            inf._coins += 3;
            PlayerPrefsManager.SetString(PrefsNames.PlayerInfo, Serializator.Encode(inf));
            PlayerPrefsManager.Save();
        }
        if (_gameState == Collections.GameStateEnum.END)
        {
            return;
        }
        _globalTick++;
    }
    
    public Collections.GameStateEnum GetGameState()
    {
        return _gameState;
    }

    public void DrawTerrainLine(Tuple<Vector3, Vector3> t)
    {
        _map.AddNewLine(t);
    } 

    public void ReloadStage(List<Tuple<Vector3, Vector3>> t)
    {
        var c = CacheResources.GetBehaviour(_playerInfo._currentCar._model).GetComponent<CarBase>();
        _playerController = new PlayerController(_map.GetTileSize(), this);
        _playerController.SetCar(c, _playerInfo._currentCar);
        _behaviours.Add(c);
        _camera.GetComponent<CameraFollowing>().SetTarget(c.gameObject.transform);
        _playerController.SetCarPosition(new Vector3(49, 0.1f, 25));
        _camera.GetComponent<CameraFollowing>().SetTarget(c.gameObject.transform);
        _playerController.SetCarRotation(new Vector3(0, 180, 0));
        _map.GenerateNewMap(100, 100, Collections.TerrainsEnum.SingleStage, t);
        _gameState = Collections.GameStateEnum.READY_TO_START;
        _readyToStartTick = _globalTick;
        _uiController.SetMessage("3");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage");
    }

    public PlayerController GetCurrentPlayer()
    {
        return _playerController;
    }
}
