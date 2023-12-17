using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class EventManager
{
    private static readonly Dictionary<Type, SortedDictionary<EventPriority, HashSet<Action<Event>>>> _events = new Dictionary<Type, SortedDictionary<EventPriority, HashSet<Action<Event>>>>();
    private static readonly Dictionary<Delegate, (EventPriority priority, Action<Event> action)> _findEvents = new Dictionary<Delegate, (EventPriority priority, Action<Event>)>();
    private static readonly Dictionary<object, HashSet<(Type type, Delegate action)>> _targetEvents = new Dictionary<object, HashSet<(Type type, Delegate action)>>();

    public static void AddListener<T>(Action<T> action, EventPriority priority = EventPriority.NORMAL) where T : Event
    {
        if (_findEvents.ContainsKey(action))
            return;

        Type type = typeof(T);
        object target = action.Target;
        Action<Event> newAction = (e) => action((T)e);

        _findEvents.Add(action, (priority, newAction));
        if (!_events.ContainsKey(type))
            _events.Add(type, new SortedDictionary<EventPriority, HashSet<Action<Event>>>());
        var dict = _events[type];
        if (!dict.ContainsKey(priority))
            dict.Add(priority, new HashSet<Action<Event>>());
        dict[priority].Add(newAction);

        if (!_targetEvents.ContainsKey(target))
            _targetEvents.Add(target, new HashSet<(Type type, Delegate action)>());
        _targetEvents[target].Add((type, action));
    }

    public static void RemoveListener<T>(Action<T> action) where T : Event
    {
        if (!_findEvents.ContainsKey(action)) return;

        var type = typeof(T);
        var target = action.Target;
        var evt = _findEvents[action];

        _events[type][evt.priority].Remove(evt.action);
        _targetEvents[target].Remove((type, action));
        _findEvents.Remove(action);
    }

    public static void RemoveTargetEvents(object target)
    {
        if (_targetEvents.TryGetValue(target, out var hashSet))
        {
            foreach (var (type, action) in hashSet)
            {
                var evt = _findEvents[action];
                _findEvents.Remove(action);
                _events[type][evt.priority].Remove(evt.action);
            }
            _targetEvents.Remove(target);
        }
    }

    public static void Broadcast<T>(T evt) where T : Event
    {
        UnityEngine.Debug.Log("event" + evt.eventName + " broadcast:" + evt);
        Type type = typeof(T);
        if (_events.TryGetValue(type, out var dict))
        {
            foreach (var actionList in dict.Values)
            {
                foreach (var action in actionList)
                    action?.Invoke(evt);
            }
        }
    }
}
