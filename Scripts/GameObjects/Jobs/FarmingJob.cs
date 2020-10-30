using Godot;
using System;
namespace BaronyGame.GameObjects.Jobs
{
	public class FarmingJob : Job
	{

		private int _yield;

		public int Yield { get => _yield; set => _yield = value; }

		public override void _Ready()
		{
			base._Ready();
			Yield = 20;
			_jobName = "Farming";

		}
		public override void WorkJob()
		{
			GD.Print("Farming");
			this._currentBarony.Food += Yield;

		}

		public override bool JobFinished()
		{
			return true;
		}

		

	}
}




