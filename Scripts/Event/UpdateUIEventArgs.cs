using Godot;
using System;


namespace BaronyGame.Events
{
    public class UpdateUIEventArgs
    {
        private readonly int _year;

        private readonly bool _updateYear;

        public int Year
        {
            get => _year;
        }

        public bool UpdateYear
        {
            get=>_updateYear;

        }

        public UpdateUIEventArgs(int year = 0,bool updateYear = false)
        {
            _year = year;
            _updateYear = updateYear;
        }

    }
}

