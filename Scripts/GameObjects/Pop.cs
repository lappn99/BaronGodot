
using System;
using BaronyGame.Singletons;
namespace BaronyGame.GameObjects
{
	public class Pop
	{


		private float happiness;
		private Development _currentDevelopment;

		public Development CurrentDevelopment { get => _currentDevelopment; set => _currentDevelopment = value; }

		public Pop()
		{

		}
		public bool IsIdle() => CurrentDevelopment == null;
	}
}

