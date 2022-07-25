using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] UnityEvent _unityEvent;

    void Awake() => _gameEvent.Register(this);

    void OnDestroy() => _gameEvent.Deregister(this);

    public void RaiseEvent() => _unityEvent.Invoke();

}
