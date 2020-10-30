using Godot;
using System;
using BaronyGame.GameObjects;
using BaronyGame.Events;
namespace BaronyGame.Singletons
{
	public class GameController : Node
	{

		private GameSignals _gameSignals;
		private int _currentYear;

		public int CurrentYear { get => _currentYear; set
		{
			_currentYear = value;
			_gameSignals.EmitSignal(nameof(GameSignals.YearChanged),_currentYear);

		} }
		private Barony _currentBarony;

		public Barony CurrentBarony
		{
			get => _currentBarony;
			set
			{
				_currentBarony = value;
				_gameSignals.EmitSignal(nameof(GameSignals.CurrentBaronyChanged), _currentBarony);
				_gameSignals.EmitSignal(nameof(GameSignals.UpdateUI));

			}
		}

		public override void _Ready()
		{
			_currentYear = 1066;
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
		}
		public void NextTurn()
		{
			_currentYear = _currentYear + 1;
			_gameSignals.EmitSignal(nameof(GameSignals.YearChanged),_currentYear);
			_gameSignals.EmitSignal(nameof(GameSignals.NextTurn));
			_gameSignals.EmitSignal(nameof(GameSignals.UpdateUI));
			
		}

	}

}
