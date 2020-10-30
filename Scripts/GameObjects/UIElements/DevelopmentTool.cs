using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
using System.Linq;
namespace BaronyGame.GameObjects.UI
{
	public class DevelopmentTool : BaronyUIElement
	{
		public override void _Ready()
		{
			base._Ready();
		}
		public override void UpdateElement()
		{
			int maxDevelopment = _currentBarony.Development.Count;
			int developmentInUse = _currentBarony.Development.Where(_currentBarony.GetAllDevelopmentInUse).Count();
			_label.Text = $"{developmentInUse}/{maxDevelopment}";

		}
	}
}
