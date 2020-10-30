using System;
using Godot;
using System.Collections.Generic;
using BaronyGame.Singletons;
using BaronyGame.Events;
namespace BaronyGame.GameObjects.Jobs
{
	public abstract class Job : StaticBody2D
	{

		
		protected Barony _currentBarony;
		protected GameSignals _gameSignals;

		protected List<Development> _workers;

		protected WindowDialog _windowDialog;

		protected string _jobName;

		public string JobName {get => _jobName;}

		public List<Development> GetWorkers{get=>_workers;}

		public override void _Ready()
		{
			GD.Print("Job ready");
			this.Connect("input_event", this, nameof(JobInputEvent));
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
			_gameSignals.Connect(nameof(GameSignals.CurrentBaronyChanged), this, nameof(UpdateBarony));
			_workers = new List<Development>();
			_windowDialog = (WindowDialog)GetNode("WindowDialog");
			_jobName = "Default";
			

		}
		public Job()
		{

		}



		public abstract bool JobFinished();
		public abstract void WorkJob();
		public void JobInputEvent(object viewport, object @event, int shape_idx)
		{
			if (@event is InputEventMouseButton mouseButtonEvent)
			{
				if (mouseButtonEvent.IsActionPressed("left_click"))
				{
					
					//AddWorker();
					
					_windowDialog.Popup_();
				}
			}
		}

		public void AddWorker()
		{
			Development development = _currentBarony.GetIdleDevelopment();

			if (development != default(Development))
			{
				_workers.Add(development);
				development.StartWorkingJob(this);

			}
		}

		public void UpdateBarony(Barony barony)
		{
			_currentBarony = barony;


		}
		


	}





}
