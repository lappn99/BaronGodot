using Godot;
using System;
namespace BaronyGame.GameObjects.UI
{

	public class TownPopup : PopupWindow
	{

		private Barony _parentBarony;

		private Label _populationLabel;

		public override void _Ready()
		{
			base._Ready();
			_parentBarony = (Barony)GetParent();
			_populationLabel = (Label)GetNode("VBoxContainer/PopulationLabel");
		}

		public override void UpdateUI()
		{
			
		}

		public override void OnPopup()
		{
			base.OnPopup();
			WindowTitle = _parentBarony.TownName;
			_populationLabel.Text = _stringProvider.GetString("TOWN_POPUP_POPULATION",_parentBarony.Population.Count);
		}
	}

}
