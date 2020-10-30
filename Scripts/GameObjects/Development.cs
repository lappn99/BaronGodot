using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using BaronyGame.GameObjects.Jobs;
using BaronyGame.Singletons;
using BaronyGame.GameObjects.States;
using BaronyGame.FSM;
namespace BaronyGame.GameObjects
{
	public class Development : Node2D
	{

		private Pop[] _workers;
		private Job _currentJob;

		public Job CurrentJob { get => _currentJob; set => _currentJob = value; }

		public bool IsIdle() => CurrentJob == null;
		protected StateManager _stateManager;

		protected GameSignals _gameSignals;

		public Development()
		{

		}
		public override void _Ready()
		{
			_stateManager = new StateManager();
			_stateManager.ChangeState(new IdleDevelopment(this));
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
			_gameSignals.Connect(nameof(GameSignals.NextTurn), this, nameof(this.NextTurn));

		}
		public Development FillDevelopment(List<Pop> populationPool, int devRatio)
		{
			_workers = populationPool.Where(p => p.IsIdle()).Take(devRatio).ToArray();
			foreach (Pop pop in _workers)
			{
				pop.CurrentDevelopment = this;
			}
			return this;
		}
		public void NextTurn()
		{
			_stateManager.NextTurn();
		}
		public void StartWorkingJob(Job job)
		{
			this.CurrentJob = job;
			_stateManager.ChangeState(new WorkingDevelopment(this));
		}
	}
}

