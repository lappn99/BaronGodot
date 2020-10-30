using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using BaronyGame.Singletons;
using BaronyGame.GameObjects.Jobs;

namespace BaronyGame.GameObjects
{
	public class Barony : StaticBody2D
	{
		private List<Pop> _population;
		private string _townName;
		private bool _playerControlled;
		private int _gold;
		private float _foodConsumptionMultiplier = 0.5f;

		private int _food;
		[Export]
		public int Gold { get => _gold; set => _gold = value; }
		[Export]
		public int Food { get => _food; set => _food = value; }
		[Export]
		public int StartingPopulation = 1000;
		[Export]
		public string TownName { get => _townName; set => _townName = value; }
		private int _developmentRatio;
		public int DevelopmentRatio { get => _developmentRatio; set => _developmentRatio = value; }
		[Export]
		public bool PlayerControlled { get => _playerControlled; set => _playerControlled = value; }
		public List<Pop> Population { get => _population; }
		private List<Development> _development;
		public List<Development> Development { get => _development; set => _development = value; }
		public float FoodConsumptionMultiplier { get => _foodConsumptionMultiplier; set => _foodConsumptionMultiplier = value; }

		private int _maxDevelopment;
		

		private GameSignals _gameSignals;


		public Func<Development, bool> GetAllDevelopmentInUse = new Func<Development, bool>(d => !d.IsIdle());
		public Func<Development, bool> GetAllIdleDevelopment = new Func<Development, bool>(d => d.IsIdle());
		

		[Export(PropertyHint.ResourceType)]
		public PackedScene _developmentResouce;
		public Barony()
		{

		}

		
		private List<Pop> PopulateTown(int population)
		{
			return Enumerable.Range(0, population).Select(i => new Pop()).ToList();
		}
		public override void _Ready()
		{

			_population = PopulateTown(StartingPopulation);
			GD.Print($"Hello {TownName} your population is {_population.Count}");
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
			_gameSignals.Connect(nameof(GameSignals.NextTurn), this, nameof(NextTurn));
			_developmentRatio = 200;
			_development = new List<Development>();
			GD.Print("Current idle works: " + Population.Where(p => p.IsIdle()).Count());
			UpdateDevelopment();
			this.Connect("input_event", this, nameof(InputEvent));
			this.InputPickable = true;
			
		}

		public List<Development> GetDevelopmentByJobType<T>() where T : Job
        {
			return Development.Where(GetAllDevelopmentInUse).Where(d => d.CurrentJob.GetType() == typeof(T)).ToList();
        }

		private void UpdateDevelopment()
		{
			_maxDevelopment = Population.Count / DevelopmentRatio;
			if (Development.Count < _maxDevelopment)
			{
				Development.AddRange(Enumerable.Range(0, _maxDevelopment - Development.Count).Select(i => CreateDevelopment()));
			}
		}



		public Development GetIdleDevelopment()
		{
			return Development.Where(GetAllIdleDevelopment).FirstOrDefault();
		}
		private void NextTurn()
		{
			UpdateDevelopment();
			UpdateStock();
			
		}

		private Development CreateDevelopment()
		{
			Development newDevelopment = (Development)_developmentResouce.Instance();
			AddChild(newDevelopment);
			newDevelopment.FillDevelopment(Population, DevelopmentRatio);
			return newDevelopment;
		}

		public void InputEvent(object viewport, object @event, int shape_idx)
		{
			if (@event is InputEventMouseButton mouseButtonEvent)
			{
				if (mouseButtonEvent.IsActionPressed("left_click"))
				{
					WindowDialog eventPopup = (WindowDialog)GetNode("../Event");
					WindowDialog window = (WindowDialog)GetNode("TownPopup");
					window.Popup_(new Rect2(this.Position,window.RectSize));
					eventPopup.Popup_();
				}
			}
		}

		public void AddPopulation(int amount)
		{
			_population.AddRange(Enumerable.Range(0,amount).Select(i => new Pop()));
			UpdateDevelopment();
		}

		private int CalculateFoodConsumption()
		{
			return Mathf.RoundToInt( Population.Count * FoodConsumptionMultiplier) + GetDevelopmentByJobType<FarmingJob>().Sum(d => d.);
		}

		public void UpdateStock()
		{
			Food -= CalculateFoodConsumption();

		}

	}


}
