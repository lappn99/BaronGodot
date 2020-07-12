using Godot;
using System;

public class PopulationTool : BaronyUIElement
{
	public override void _Ready()
	{
		base._Ready();
	}
	public override void UpdateElement(int year)
	{
		_label.Text = this._currentBarony.Population.Count.ToString();
	}
}
