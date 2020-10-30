using Godot;
using System;
using BaronyGame.GameObjects.Jobs;
using BaronyGame.Singletons;

namespace BaronyGame.GameObjects.UI
{


	
	public class JobPopupWindow : PopupWindow
	{

		protected Label _developmentsLabel;
		protected Job _parentJob;

		protected string _numDevelopmentsFormatString = "Workers: {0}";
		protected VBoxContainer _vBox;
		protected Button _addWorkersButton;

			

		public override void _Ready()
		{
			base._Ready();
			
			_parentJob = (Job)GetParent();
			
			_developmentsLabel = (Label)GetNode("BoxContainer/NumDevelopments");
			_vBox = (VBoxContainer)GetNode("BoxContainer");
			_addWorkersButton = (Button)GetNode("BoxContainer/AddWorkers");
			_addWorkersButton.Connect("button_up",this,nameof(OnAddWorkersUp));
			
			
			
		}
		public override void OnPopup()
		{
			base.OnPopup();
			WindowTitle = _parentJob.JobName;
			//Resize();
		}

		public override void UpdateUI()
		{

			
			_developmentsLabel.Text = _stringProvider.GetString("JOB_POPUP_WINDOW_NUM_WORKERS",_parentJob.GetWorkers.Count);
			
		}

		public void Resize()
		{
			RectSize = _vBox.RectSize;
		}

		public virtual void OnAddWorkersUp()
		{
			_parentJob.AddWorker();
			_gameSignals.EmitSignal(nameof(GameSignals.UpdateUI));
		}

	}
}
