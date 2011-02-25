using System;

namespace AlgorithmsRunner
{
    internal class Timer
    {
        private DateTime _time;

        public void Start()
        {
            _time = DateTime.Now;
        }

        public double GetTime()
        {
            return DateTime.Now.Subtract(_time).TotalSeconds;
        }
    }
}
