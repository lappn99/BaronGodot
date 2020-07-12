using Godot;
using System;

public class DevelopmentTool : BaronyUIElement
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public override void UpdateElement(int year)
	{
		_label.Text = _currentBarony.Development.Count.ToString();


	}


}
