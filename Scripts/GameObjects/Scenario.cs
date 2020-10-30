using Godot;
using System;
using GCollections = Godot.Collections;
using BaronyGame.Singletons;
using System.Reflection;
using System.Linq;
using BaronyGame.GameObjects.Jobs;
namespace BaronyGame.GameObjects
{
	public class Scenario : Node2D
	{
		[Export(PropertyHint.File, "*.json")]
		private string _scenarioFile;

		private string _scenarioName;

		private int _year;

		[Export(PropertyHint.ResourceType)]
		private PackedScene _baronyScene;

		private GameController _gameController;

		public override void _Ready()
		{
			_gameController = (GameController)GetNode("/root/GameController");
			LoadScenario();


		}

		public void LoadScenario()
		{
			if (_scenarioFile != null)
			{
				File dataFile = new File();
				dataFile.Open(_scenarioFile, File.ModeFlags.Read);
				string dataText = dataFile.GetAsText();
				dataFile.Close();
				JSONParseResult result = JSON.Parse(dataText);
				if (result.Error != 0)
				{
					return;
				}

				GCollections.Dictionary scenario = result.Result as GCollections.Dictionary;
				_scenarioName = scenario["name"] as string;
				GD.Print($"Loaded scenario: {_scenarioName}");
				_year = Convert.ToInt32(scenario["starting_year"]);

				GD.Print($"Year: {_year}");
				_gameController.CurrentYear = _year;
				GCollections.Array jobs = scenario["jobs"] as GCollections.Array;
				foreach(GCollections.Dictionary jobData in jobs)
				{
					SpawnJob(jobData);
				}
				GCollections.Array baronies = scenario["baronies"] as GCollections.Array;
				foreach (GCollections.Dictionary baronyData in baronies)
				{
					SpawnBarony(baronyData);
				}
			}
		}
		public bool SpawnBarony(GCollections.Dictionary baronyData)
		{
			bool result = true;
			Barony newBarony = (Barony)_baronyScene.Instance();
			newBarony.TownName = baronyData["townName"] as string;
			newBarony.Position = new Vector2((float)baronyData["x"], (float)baronyData["y"]);
			newBarony.Gold = Convert.ToInt32(baronyData["gold"]);
			newBarony.Food = Convert.ToInt32(baronyData["food"]);
			newBarony.StartingPopulation = Convert.ToInt32(baronyData["startingPopulation"]);
			newBarony.PlayerControlled = Convert.ToBoolean(baronyData["playerControlled"]);

			this.AddChild(newBarony);

			if (newBarony.PlayerControlled)
			{
				_gameController.CurrentBarony = newBarony;
			}

			return result;
		}

		public bool SpawnJob(GCollections.Dictionary jobData)
		{
			
			Type type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == jobData["type"] as string);
			PackedScene scene = (PackedScene)ResourceLoader.Load(jobData["resourceFile"] as string);
			
			Job job = (Job)scene.Instance();
			job.Position = new Vector2((float)jobData["x"],(float)jobData["y"]);
			this.AddChild(job);
			return true;

		}
	}
}
