using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.UI
{
	public class GoldTool : BaronyUIElement
	{
		// Declare member variables here. Examples:
		// private int a = 2;
		// private string b = "text";

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			base._Ready();
		}

		public override void UpdateElement()
		{
			_label.Text = this._currentBarony.Gold.ToString();


		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
