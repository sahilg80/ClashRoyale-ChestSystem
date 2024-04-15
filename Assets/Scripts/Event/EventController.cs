﻿using System;

namespace Assets.Scripts.Event
{
    public class EventController
    {
        private event Action baseEvent;
        public void InvokeEvent() => baseEvent?.Invoke();
        public void AddListener(Action listener) => baseEvent += listener;
        public void RemoveListener(Action listener) => baseEvent -= listener;
    }

    public class EventController<T>
    {
        private event Action<T> baseEvent;
        public void InvokeEvent(T type) => baseEvent?.Invoke(type);
        public void AddListener(Action<T> listener) => baseEvent += listener;
        public void RemoveListener(Action<T> listener) => baseEvent -= listener;
    }

    public class EventController<T,U>
    {
        private event Action<T,U> baseEvent;
        public void InvokeEvent(T type1, U type2) => baseEvent?.Invoke(type1, type2);
        public void AddListener(Action<T, U> listener) => baseEvent += listener;
        public void RemoveListener(Action<T, U> listener) => baseEvent -= listener;
    }
}
