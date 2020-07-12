using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public class Barony : Node2D
{
	private List<Pop> _population;
	private string _townName;
	private bool _playerControlled;
	private int _gold;
	[Export]
	public int Gold{get=> _gold; set=> _gold = value;}
	[Export]
	public int StartingPopulation = 1000;
	[Export]
	public string TownName{get=> _townName; set=> _townName = value;}
	private int _developmentRatio;
	public int DevelopmentRatio{get=>_developmentRatio; set=> _developmentRatio = value;}
	[Export]
	public bool PlayerControlled{get=>_playerControlled; set=>_playerControlled = value;}
	public List<Pop> Population {get => _population;}
	private List<Development> _development;
	public List<Development> Development {get=> _development; set => _development = value;}
	private int _maxDevelopment;

	private GameSignals _gameSignals;



	public Barony()
	{

	}
	private List<Pop> PopulateTown(int population)
	{
		return Enumerable.Range(0,population).Select(i => new Pop()).ToList();
	}
	public override void _Ready()
	{
		_population = PopulateTown(StartingPopulation);
		GD.Print($"Hello {TownName} your population is {_population.Count}");
		_gameSignals = (GameSignals)GetNode("/root/GameSignals");
		_gameSignals.Connect(nameof(GameSignals.NextTurn),this,nameof(GameSignals.NextTurn));
		_developmentRatio = 200;
		_development = new List<Development>();
	}
	private void CalculateMaxDevelopment()
	{
		_maxDevelopment = Population.Count/DevelopmentRatio;
		if(Development.Count < _maxDevelopment)
		{
			Development.AddRange(Enumerable.Range(0,_maxDevelopment - Development.Count).Select(i => new Development()));
		}
	}
	private void NextTurn()
	{
		CalculateMaxDevelopment();

	}


}
