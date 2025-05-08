using System;
using System.Collections.Generic;

namespace Game.Systems.Event
{
    public static class EventManager
    {
        private static readonly Dictionary<Type, Delegate> _eventTable = new();

        public static void Subscribe<T>(Action<T> callback)
        {
            if (_eventTable.TryGetValue(typeof(T), out var existing))
                _eventTable[typeof(T)] = Delegate.Combine(existing, callback);
            else
                _eventTable[typeof(T)] = callback;
        }

        public static void Unsubscribe<T>(Action<T> callback)
        {
            if (_eventTable.TryGetValue(typeof(T), out var existing))
            {
                var updated = Delegate.Remove(existing, callback);
                if (updated == null)
                    _eventTable.Remove(typeof(T));
                else
                    _eventTable[typeof(T)] = updated;
            }
        }

        public static void Publish<T>(T eventData)
        {
            if (_eventTable.TryGetValue(typeof(T), out var callback))
            {
                ((Action<T>)callback)?.Invoke(eventData);
            }
        }

        public static void ClearAll()
        {
            _eventTable.Clear();
        }
    }
}