using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.UI
{
	public class FoodTool : BaronyUIElement
	{

		public override void _Ready()
		{
			base._Ready();
		}

		public override void UpdateElement()
		{
			this._label.Text = $"{this._currentBarony.Food.ToString()} - {this._currentBarony.Population.Count * this._currentBarony.FoodConsumptionMultiplier}";
		}


	}
}
