using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.UI
{
    public class PopulationTool : BaronyUIElement
    {
        public override void _Ready()
        {
            base._Ready();

        }
        public override void UpdateElement()
        {
            _label.Text = this._currentBarony.Population.Count.ToString();
        }
    }
}
