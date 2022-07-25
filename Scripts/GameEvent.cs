using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent();
    }

    public void Register(GameEventListener gameEventListener) => _listeners.Add(gameEventListener);
    public void Deregister(GameEventListener gameEventListener) => _listeners.Remove(gameEventListener);
}
