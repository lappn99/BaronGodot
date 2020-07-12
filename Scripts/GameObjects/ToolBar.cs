using Godot;
using System;

public class ToolBar : PanelContainer
{
	
	private Button _nextTurn;
	[Export]
	public NodePath NextTurnPath;
	private GameController _gameController;

	private GameSignals _gameSignals;

	private Label _yearLabel;

	public override void _Ready()
	{
		_nextTurn = (Button)GetNode(NextTurnPath);	
		_gameController = (GameController)GetNode("/root/GameController");
		_gameSignals = (GameSignals)GetNode("/root/GameSignals");
		_yearLabel = (Label)GetNode("ToolBarContainer/VBoxContainer/year_label");
		_gameSignals.Connect(nameof(GameSignals.UpdateUI),this,nameof(UpdateElement));
	}

	private void NextTurnButtonUp()
	{
		_gameController.NextTurn();
	}

	private void UpdateElement(int year)
	{
		_yearLabel.Text = year.ToString();
	}
}



