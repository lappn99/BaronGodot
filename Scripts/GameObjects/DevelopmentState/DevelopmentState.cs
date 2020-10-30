using System;
using BaronyGame.FSM;
namespace BaronyGame.GameObjects.States
{
	public abstract class DevelopmentState : IState
	{
		private Development _development;

		public Development development { get => _development; set => _development = value; }

		public DevelopmentState(Development development)
		{
			_development = development;

		}
		public abstract void Exit();
		public abstract void Ready();
		public abstract void NextTurn();
	}
}
