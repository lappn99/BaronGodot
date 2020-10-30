using Godot;
using System;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.UI
{
	public class ToolBar : PanelContainer
	{

		private Button _nextTurn;
		[Export]
		public NodePath NextTurnPath;
		private GameController _gameController;

		private GameSignals _gameSignals;

		private Label _yearLabel;

		private StringProvider _stringProvider;

		public override void _Ready()
		{
			_nextTurn = (Button)GetNode(NextTurnPath);
			_gameController = (GameController)GetNode("/root/GameController");
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
			_yearLabel = (Label)GetNode("ToolBarContainer/VBoxContainer/year_label");
			//_gameSignals.Connect(nameof(GameSignals.UpdateUI), this, nameof(UpdateElement));
			_gameSignals.Connect(nameof(GameSignals.YearChanged),this,nameof(UpdateElement));
			_stringProvider = (StringProvider)GetNode("/root/StringProvider");
		}

		private void NextTurnButtonUp()
		{
			_gameController.NextTurn();
		}

		private void UpdateElement(int year)
		{
			//GD.Print("Year changed");
			_yearLabel.Text = _stringProvider.GetString("TOOLBAR_YEAR",_gameController.CurrentYear);
		}
	}
}



