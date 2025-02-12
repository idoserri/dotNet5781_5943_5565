﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Clock
    {
        #region singelton
        static readonly Clock instance = new Clock();
        static Clock() { }// static ctor to ensure instance init is done just before first usage
        public Clock() { }
        public static Clock Instance { get => instance; }// The public Instance property to use
        #endregion

        private int rate;
        public int Rate { get; set; }
        private event Action<TimeSpan> clockObserver;

        public event Action<TimeSpan> ClockObserver
        {
            add { clockObserver = value; }
            remove { clockObserver -= value; }
        }

        private TimeSpan time;
        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                clockObserver?.Invoke(time);
            }
        }


    }
}
