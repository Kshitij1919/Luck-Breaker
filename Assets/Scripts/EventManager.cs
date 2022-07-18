
using UnityEngine;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance = null;
    private Dictionary<object, Delegate> eventDictionary;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Init();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static EventManager Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    void Init()
    {
        if (eventDictionary == null)
            eventDictionary = new Dictionary<object, Delegate>();
    }

    #region --- Register Events ---
    public void RegisterEvent(object eventName, Action handler)
    {
        Register(eventName, handler);
    }

    public void RegisterEvent<T>(object eventName, Action<T> handler)
    {
        Register(eventName, handler);
    }

    // public void RegisterEvent<T, U>(object eventName, Action<T, U> handler)
    // {
    //     Register(eventName, handler);
    // }

    // public void RegisterEvent<T, U, V>(object eventName, Action<T, U, V> handler)
    // {
    //     Register(eventName, handler);
    // }
    // public void RegisterEvent<T, U, V, W>(object eventName, Action<T, U, V, W> handler)
    // {
    //     Register(eventName, handler);
    // }
    #endregion

    #region --- Execute Events ---
    public void ExecuteEvent(object eventName)
    {
        Action action = GetDelegate(eventName) as Action;
        if (action != null)
            action.Invoke();
    }

    public void ExecuteEvent<T>(object eventName, T arg1)
    {
        Action<T> action = GetDelegate(eventName) as Action<T>;
        if (action != null)
            action.Invoke(arg1);
    }

    // public void ExecuteEvent<T, U>(object eventName, T arg1, U arg2)
    // {
    //     Action<T, U> action = GetDelegate(eventName) as Action<T, U>;
    //     if (action != null)
    //         action.Invoke(arg1, arg2);
    // }

    // public void ExecuteEvent<T, U, V>(object eventName, T arg1, U arg2, V arg3)
    // {
    //     Action<T, U, V> action = GetDelegate(eventName) as Action<T, U, V>;
    //     if (action != null)
    //         action.Invoke(arg1, arg2, arg3);
    // }
    // public void ExecuteEvent<T, U, V, W>(object eventName, T arg1, U arg2, V arg3, W arg4)
    // {
    //     Action<T, U, V, W> action = GetDelegate(eventName) as Action<T, U, V, W>;
    //     if (action != null)
    //         action.Invoke(arg1, arg2, arg3, arg4);
    // }
    #endregion

    #region --- UnRegister Events ---
    public void UnRegisterEvent(object eventName, Action handler)
    {
        Unregister(eventName, handler);
    }

    public void UnRegisterEvent<T>(object eventName, Action<T> handler)
    {
        Unregister(eventName, handler);
    }

    // public void UnRegisterEvent<T, U>(object eventName, Action<T, U> handler)
    // {
    //     Unregister(eventName, handler);
    // }

    // public void UnRegisterEvent<T, U, V>(object eventName, Action<T, U, V> handler)
    // {
    //     Unregister(eventName, handler);
    // }
    // public void UnRegisterEvent<T, U, V, W>(object eventName, Action<T, U, V, W> handler)
    // {
    //     Unregister(eventName, handler);
    // }
    #endregion

    #region --- Helper Methods ----
    private Delegate GetDelegate(object eventName)
    {
        Delegate result;
        if (eventDictionary.TryGetValue(eventName, out result))
            return result;
        return null;
    }

    private void Register(object eventName, Delegate handler)
    {
        Delegate del;
        if (eventDictionary.TryGetValue(eventName, out del))
            eventDictionary[eventName] = Delegate.Combine(del, handler);
        else
            eventDictionary.Add(eventName, handler);
    }

    private void Unregister(object eventName, Delegate handler)
    {
        Delegate del;
        if (eventDictionary.TryGetValue(eventName, out del))
        {
            eventDictionary[eventName] = Delegate.Remove(del, handler);
        }
    }

    public void ClearTable()
    {
        eventDictionary.Clear();
    }

    private void OnDestroy()
    {
        this.ClearTable();
    }
    #endregion
}