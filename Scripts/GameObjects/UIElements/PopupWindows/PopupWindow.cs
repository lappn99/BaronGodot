using Godot;
using System;
using BaronyGame.Singletons;
namespace BaronyGame.GameObjects.UI
{
	public abstract class PopupWindow : WindowDialog
	{

		protected GameSignals _gameSignals;
		protected StringProvider _stringProvider;	

		protected GameController _gameController;
		
		public override void _Ready()
		{
			this.Connect("about_to_show",this,nameof(OnPopup));
			_gameSignals = (GameSignals)GetNode("/root/GameSignals");
			_gameSignals.Connect(nameof(GameSignals.UpdateUI),this,nameof(UpdateUI));
			_stringProvider = (StringProvider)GetNode("/root/StringProvider");
			_gameController = (GameController)GetNode("/root/GameController");
		}

		public virtual void OnPopup()
		{
			GD.Print("Popup");
		}

		public abstract void UpdateUI();

	   
	}
}

