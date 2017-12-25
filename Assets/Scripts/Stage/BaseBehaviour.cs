using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    protected int _sceneTick = -1;
    protected PlayerController _player;

    public void Start()
    {
        OnStart();
    }

    public void UpdateBehaviour(int t)
    {
        _sceneTick = t;
        OnUpdateBehaviour();
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnUpdateBehaviour()
    {

    }

    public void SetPlayer(PlayerController p)
    {
        _player = p;
    }
}
