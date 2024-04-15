﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
