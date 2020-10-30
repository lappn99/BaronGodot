using Godot;
using System;
using GCollections = Godot.Collections;
using BaronyGame.Helpers;
using NLua;
using BaronyGame.Singletons;
namespace BaronyGame.GameObjects.UI
{

	public class EventWindow : PopupWindow
	{
		[Export(PropertyHint.File, "*.json")]
		private string _eventFile;


		private VBoxContainer _eventOptions;
		private Lua _lua;

		


		public override void _Ready()
		{
			base._Ready();
			_lua = new Lua();
			
			_eventOptions = (VBoxContainer)GetNode("EventOptions");
			LoadEvent();
			base.Popup_();
		}

		public override void UpdateUI()
		{
			
		}

		

		private void LoadEvent()
		{
			JSONParseResult data;
			if(IOHelper.ReadJsonFile(_eventFile,out data))
			{
				GCollections.Dictionary eventDict = data.Result as GCollections.Dictionary;
				GCollections.Array options = eventDict["options"] as GCollections.Array;
				foreach(GCollections.Dictionary option in options)
				{
					Button button = new Button();
					_eventOptions.AddChild(button);
					
					button.Text = _stringProvider.GetString( option["text"] as string) ;
					button.HintTooltip = _stringProvider.GetString( option["tooltip"] as string);
					button.Connect("button_up",this,nameof(OnActionClick), new GCollections.Array {option["action"],eventDict["lua_file"]});
				}

			}	
		}

		private void OnActionClick(string action,string fileName)
		{
			File luaFile = new File();
			luaFile.Open(fileName, File.ModeFlags.Read);
			_lua["action"] = action;
			_lua["barony"] = _gameController.CurrentBarony;
			_lua.DoString(luaFile.GetAsText());
			_gameSignals.EmitSignal(nameof(GameSignals.UpdateUI));
			luaFile.Close();
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
