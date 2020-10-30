using Godot;
using System;
using  BaronyGame.GameObjects;

namespace BaronyGame.Singletons
{
	public class GameSignals : Node
	{
		[Signal]
		public delegate void UpdateUI();

		[Signal]
		public delegate void YearChanged(int year);

		[Signal]
		public delegate void NextTurn();

		[Signal]
		public delegate void CurrentBaronyChanged(Barony barony);

	}
}
